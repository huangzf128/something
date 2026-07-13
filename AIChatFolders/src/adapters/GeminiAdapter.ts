/**
 * GeminiAdapter.ts
 * Implementation for Google Gemini with native menu injection.
 */
import { LeftSidebarAdapter } from './LeftSidebar';
import { FolderManager } from '../models/FolderManager';
import type { FolderData } from '../models/Folder';

export class GeminiAdapter extends LeftSidebarAdapter {
    platformId = 'Gemini';
    // Gemini's menu content container selector
    itemSelector = 'div.mat-mdc-menu-content';

	injectAddButtons(): void {
        const menuContainer = document.querySelector(this.itemSelector);
        if (!menuContainer || menuContainer.querySelector('.aichat-folder-menu-item')) return;

        const button = document.createElement('button');
        button.className = 'mat-mdc-menu-item mat-focus-indicator aichat-folder-menu-item';
        button.innerHTML = `
            <mat-icon class="mat-icon google-symbols">folder_open</mat-icon>
            <span class="mat-mdc-menu-item-text" style="flex:1">Add to Folder</span>
            <span style="font-size: 10px; opacity: 0.5;">▶</span>
        `;

        menuContainer.appendChild(button);

        button.addEventListener('mouseenter', async () => {
            this.clearCloseTimer();
            const rect = button.getBoundingClientRect();
            const folders = await FolderManager.getFolders();
            this.showLevelMenu(rect.right + 2, rect.top, folders);
        });

        button.addEventListener('mouseleave', () => this.startCloseTimer());
    }

	// getChatInfo() {
    //     const chatId = window.location.pathname.split('/').pop() || '';
    //     const activeChatEl = document.querySelector('.is-active mdc-list-item--activated');
    //     const title = activeChatEl?.querySelector('.title-text')?.textContent || document.title;

    //     return { id: chatId, title: title.trim(), url: window.location.href };
    // }


	getChatInfo() {
		// 💡 Locate the anchor element using your precise discovered selectors
		const activeLinkEl = document.querySelector('gem-nav-list-item.always-show-hovered-trailing-content');
		
		const anchorEl = activeLinkEl?.querySelector('a');
		const chatId = anchorEl?.getAttribute('href')?.split('/').pop() || 
                   window.location.pathname.split('/').pop() || '';

		const title = activeLinkEl?.querySelector('.title-text')?.textContent?.trim() || 
                  document.title;
		
		return { id: chatId, title: title, url: window.location.href };
	}

    /**
     * Resolves raw identifier strings back into functional navigation paths.
     */
    resolveChatUrl(chatId: string): string {
        return `https://gemini.google.com/app/${chatId}`;
    }


	/**
	 * Smooth navigation for Gemini SPA
	 */
	async smoothNavigate(chatId: string, fallbackUrl: string): Promise<void> {
		const SELECTOR = `div.chat-history a[href*="${chatId}"]`;
		const container = document.querySelector('infinite-scroller');
		
		const tryClick = (): boolean => {
			const nativeLink = document.querySelector(SELECTOR) as HTMLAnchorElement | null;
			if (nativeLink) {
				nativeLink.click();
				return true;
			}
			return false;
		};

		if (tryClick()) return;

		if (container) {
			for (let i = 0; i < 10; i++) {
				container.scrollTop = container.scrollHeight;
				await new Promise(r => setTimeout(r, 450));
				if (tryClick()) return;
			}
		}

		window.location.href = fallbackUrl;
	}	
}