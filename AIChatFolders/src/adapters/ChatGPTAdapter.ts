/**
 * ChatGPTAdapter.ts
 * Implementation for OpenAI ChatGPT with native menu injection.
 */
import { LeftSidebarAdapter } from './LeftSidebar';

export class ChatGPTAdapter extends LeftSidebarAdapter {
    platformName = 'ChatGPT';
    
    // ChatGPT usually uses role="menu" for the popover container
    itemSelector = '[role="menu"]';

    injectAddButtons(): void {
        const menuContainer = document.querySelector(this.itemSelector);
        
        // Skip if menu not found or button already exists
        if (!menuContainer || menuContainer.querySelector('.aichat-folder-menu-item')) return;

        this.createMenuItem(menuContainer as HTMLElement);
    }

    private createMenuItem(menuContainer: HTMLElement): void {
        // Find an existing menu item to clone its classes for consistent styling
        const originalItem = menuContainer.querySelector('[role="menuitem"]');
        if (!originalItem) return;

        const button = document.createElement('div');
        // Copy original classes to inherit ChatGPT's dark/light mode styles
        button.className = originalItem.className + ' aichat-folder-menu-item';
        button.setAttribute('role', 'menuitem');
        button.style.cursor = 'pointer';

        // ChatGPT uses Lucide icons (SVG) or similar. We'll use a compatible SVG structure.
        button.innerHTML = `
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="h-4 w-4">
                <path d="M4 20h16a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.93a2 2 0 0 1-1.66-.9l-.82-1.2A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13c0 1.1.9 2 2 2Z"></path>
                <line x1="12" y1="10" x2="12" y2="16"></line>
                <line x1="9" y1="13" x2="15" y2="13"></line>
            </svg>
            <span>Add to Folder</span>
        `;

        // Inject before the "Delete" item if possible, which is usually last
        const deleteItem = menuContainer.querySelector('.text-token-text-error');
        if (deleteItem) {
            menuContainer.insertBefore(button, deleteItem);
        } else {
            menuContainer.appendChild(button);
        }

        button.addEventListener('click', (e) => {
            e.stopPropagation();
            const info = this.getChatInfo();
            console.log(info);

            window.dispatchEvent(new CustomEvent('aichat:open-folder-selector', { detail: info }));
            
            // Close the menu by clicking away
            document.body.click();
        });
    }

    getChatInfo() {
        // ChatGPT encodes conversation ID in the URL: /c/uuid
        const pathParts = window.location.pathname.split('/');
        const chatId = pathParts[pathParts.length - 1];
        
        // ChatGPT's sidebar active item title
        const activeChatEl = document.querySelector('#history a[data-active] div.truncate span');
        const titleText = activeChatEl?.textContent || document.title;

        return {
            id: chatId || Date.now().toString(),
            title: titleText.trim(),
            url: window.location.href
        };
    }

    observeChanges(): void {
        const observer = new MutationObserver(() => this.injectAddButtons());
        observer.observe(document.body, { childList: true, subtree: true });
    }

	/**
     * Resolves raw identifier strings back into functional navigation paths.
     */
    resolveChatUrl(chatId: string): string {
        return `https://chatgpt.com/c/${chatId}`;
    }
}