import { RightSidebar } from './ui/RightSidebar';
import { FolderManager } from './models/FolderManager';
import { GeminiAdapter } from './adapters/GeminiAdapter';
import { ChatGPTAdapter } from './adapters/ChatGPTAdapter';
import type { LeftSidebarAdapter } from './adapters/LeftSidebar';

// Create a main entry function
async function initializeApp() {

    const adapter = getAdapter();

    // 1. Initialize UI
    const sidebar = new RightSidebar(adapter); 

    // 2. Load and render data
    // Now 'await' is inside an async function, which is allowed
    const folders = await FolderManager.getFolders();
    sidebar.render(folders);

    // 3. Initialize Adapter (e.g., Gemini)
	if (adapter) {
		adapter.injectAddButtons();
		adapter.observeChanges();
	}

    console.log('AIChatFolders: App initialized.');
}

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