/**
 * @file Entry point for the AIChatFolders application.
 * Handles the application lifecycle, UI mounting, and adapter binding.
 */
import { RightSidebar } from './ui/RightSidebar';
import { FolderManager } from './models/FolderManager';
import { GeminiAdapter } from './adapters/GeminiAdapter';
import { ChatGPTAdapter } from './adapters/ChatGPTAdapter';
import type { LeftSidebarAdapter } from './adapters/LeftSidebar';

/**
 * Core initialization function that assembles the UI and activates the adapter.
 * Runs asynchronously to fetch remote or local folder configurations.
 */
async function initializeApp() {

    const adapter = getAdapter();
	if (!adapter) return;

	FolderManager.init(adapter);

    // 1. Initialize UI
    const sidebar = new RightSidebar(adapter); 

    // 2. Load and render data
    const folders = await FolderManager.getFolders();
    sidebar.render(folders);

    // 3. Initialize Adapter (e.g., Gemini)
	if (adapter) {
		adapter.injectAddButtons();
		adapter.observeChanges();
	}

    console.log('AIChatFolders: App initialized.');
}

/**
 * Detects the current host environment and returns the matching AI platform adapter.
 * * @returns {LeftSidebarAdapter | null} The matching adapter instance, or null if unsupported.
 */
function getAdapter(): LeftSidebarAdapter | null {
    const host = window.location.hostname;

    if (host.includes('gemini.google.com')) {
        return new GeminiAdapter();
    } 
    
    if (host.includes('chatgpt.com') || host.includes('chat.openai.com')) {
        return new ChatGPTAdapter();
    }

    return null;
}

// Execute the entry function
initializeApp().catch(err => {
    console.error('AIChatFolders initialization failed:', err);
});