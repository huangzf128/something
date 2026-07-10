/**
 * Interface for site-specific sidebar adaptations.
 * Defines the contract for interacting with different AI platform UIs.
 */
export abstract class LeftSidebarAdapter {
    abstract platformName: string;
    abstract itemSelector: string;
    protected closeTimer: any = null;

    /**
     * Injects the "Add to Folder" button or menu item into the platform's UI.
     */
    abstract injectAddButtons(): void;

	/**
     * Entry point: Start observing the platform's DOM changes.
     */
    observeChanges(): void {
        const observer = new MutationObserver(() => this.injectAddButtons());
        observer.observe(document.body, { childList: true, subtree: true });
    }

    /**
     * Extracts chat metadata from a given DOM element.
     */
    abstract getChatInfo(): { id: string; title: string; url: string };

	/**
     * SHARED: Create the cascading menu and manage its lifecycle.
     */
	protected showLevelMenu(x: number, y: number, folders: any[], level: number = 0): void {
		if (level === 0) this.removeCascadeMenus();

		const pureFolders = (folders || []).filter(f => !f.isChat);
		if (pureFolders.length === 0 && level > 0) return;

		const menu = document.createElement('div');
		menu.className = `aichat-cascade-menu level-${level}`;

		menu.addEventListener('mouseenter', () => this.clearCloseTimer());
		menu.addEventListener('mouseleave', () => this.startCloseTimer());

		pureFolders.forEach(folder => {
			const item = document.createElement('div');
			item.className = 'aichat-cascade-item';
			const hasChildren = folder.children && folder.children.some((c: any) => !c.isChat);

			item.innerHTML = `
				<span>${folder.name}</span>
				${hasChildren ? '<span style="font-size: 10px; margin-left:2px;">▶</span>' : ''}
			`;

			item.addEventListener('click', async (e) => {
				e.stopPropagation();
				const info = this.getChatInfo();
				window.dispatchEvent(new CustomEvent('aichat:save-to-folder', {
					detail: { folderId: folder.id, chatInfo: info }
				}));
				this.removeCascadeMenus();
				document.body.click();
			});

			if (hasChildren) {
				item.addEventListener('mouseenter', () => {
					this.clearCloseTimer();
					const rect = item.getBoundingClientRect();
					// Pass pureFolders to avoid re-filtering
					const childFolders = folder.children.filter((c: any) => !c.isChat);
					this.showLevelMenu(rect.right, rect.top, childFolders, level + 1);
				});
			} else {
				item.addEventListener('mouseenter', () => {
					this.clearCloseTimer();
					this.removeSubMenus(level);
				});
			}
			menu.appendChild(item);
		});

		document.body.appendChild(menu);

		// 💡 Boundary check: adjust if menu overflows viewport
		const menuHeight = menu.offsetHeight;
		const viewportHeight = window.innerHeight;
		const padding = 10;

		let adjustedY = y;
		if (y + menuHeight > viewportHeight - padding) {
			adjustedY = Math.max(padding, viewportHeight - menuHeight - padding);
		}

		// 💡 Also check right boundary (prevent overflow on the right)
		const menuWidth = menu.offsetWidth;
		const viewportWidth = window.innerWidth;
		let adjustedX = x;
		if (x + menuWidth > viewportWidth - padding) {
			adjustedX = Math.max(padding, viewportWidth - menuWidth - padding);
		}

		menu.style.top = `${adjustedY}px`;
		menu.style.left = `${adjustedX}px`;
	}

    protected startCloseTimer(): void {
        this.clearCloseTimer();
        this.closeTimer = setTimeout(() => this.removeCascadeMenus(), 300);
    }

    protected clearCloseTimer(): void {
        if (this.closeTimer) {
            clearTimeout(this.closeTimer);
            this.closeTimer = null;
        }
    }

    protected removeCascadeMenus(): void {
        document.querySelectorAll('.aichat-cascade-menu').forEach(el => el.remove());
    }

    protected removeSubMenus(currentLevel: number): void {
        document.querySelectorAll('.aichat-cascade-menu').forEach(menu => {
            const level = parseInt(menu.className.match(/level-(\d+)/)?.[1] || "0");
            if (level > currentLevel) menu.remove();
        });
    }

	/**
     * 💡 NEW: Compiles a standard raw identifier into a full, navigable platform hyperlink.
     * @param chatId - The unique session string.
     */
    abstract resolveChatUrl(chatId: string): string;

	/**
     * Smooth navigation for SPA platforms.
     * Default implementation: fallback to full page reload.
     * Subclasses should override for platform-specific SPA navigation.
     */
    async smoothNavigate(chatId: string, fallbackUrl: string): Promise<void> {
        // Default: full page reload
        window.location.href = fallbackUrl;
    }
}