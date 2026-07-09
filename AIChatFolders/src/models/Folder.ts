export interface ChatItem {
    id: string;
    title: string;
    url: string;
}

// Define the interface for data binding
export interface FolderData {
    id: string;
    name: string;
	isCollapsed?: boolean;
    icon: string;
    color: string;
	parentId: string | null; // NULL for top-level folders
    children: FolderData[];  // Recursive structure
    items: ChatItem[];       // Chats stored in this folder

	// 💡 A simple flag is enough to tell if this node is a folder or a chat leaf
    isChat?: boolean; 
    chatId?: string; // The raw conversation ID
}