/**
 * GeminiAdapter.ts
 * Implementation for Google Gemini with native menu injection.
 */
import { LeftSidebarAdapter } from './LeftSidebar';
import { FolderManager } from '../models/FolderManager';
import type { FolderData } from '../models/Folder';

export class GeminiAdapter extends LeftSidebarAdapter {
    platformName = 'Gemini';
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
		// 💡 Gemini's URL structure is normally /app/chatId or /app/chat/chatId
		const pathParts = window.location.pathname.split('/');
		const chatId = pathParts[pathParts.length - 1] || '';
		
		// 💡 Locate the anchor element using your precise discovered selectors
		const activeLinkEl = document.querySelector('gem-nav-list-item.always-show-hovered-trailing-content');
		
		// 💡 Extract the specific title text block container safely
		let title = activeLinkEl?.querySelector('.title-text')?.textContent?.trim();
		
		// Safety fallback just in case the DOM structure changes temporarily
		if (!title) {
			title = document.title;
		}
		
		return { id: chatId, title: title, url: window.location.href };
	}

    /**
     * Resolves raw identifier strings back into functional navigation paths.
     */
    resolveChatUrl(chatId: string): string {
        return `https://gemini.google.com/app/${chatId}`;
    }	
}