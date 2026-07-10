/**
 * FolderManager.ts
 * Handles data persistence using chrome.storage.local.
 */
import type { FolderData, ChatItem } from './Folder';

export class FolderManager {
    private static STORAGE_KEY = 'ai_chat_folders';

    /**
     * Retrieves all folders from local storage.
     */
    static async getFolders(): Promise<FolderData[]> {
        return new Promise((resolve) => {
				chrome.storage.local.get([this.STORAGE_KEY], (result) => {
				const data = result[this.STORAGE_KEY] as FolderData[] | undefined;
				resolve(data || []);
			});
        });
    }

    /**
     * Saves the entire folder array to storage.
     */
	static async saveFolders(folders: FolderData[]): Promise<void> {
		return new Promise((resolve, reject) => {
			chrome.storage.local.set({ [this.STORAGE_KEY]: folders }, () => {
				if (chrome.runtime.lastError) {
					reject(chrome.runtime.lastError);
				} else {
					resolve();
				}
			});
		});
	}

	static async addFolder(name: string, color: string, icon: string, parentId: string | null = null): Promise<FolderData[]> {
        const allFolders = await this.getFolders();
        const newFolder: FolderData = {
            id: Date.now().toString(),
            name, color, icon, parentId,
            children: [],
            items: []
        };

        if (!parentId) {
            allFolders.unshift(newFolder);
        } else {
            this.findAndAddChild(allFolders, parentId, newFolder);
        }

        await this.saveFolders(allFolders);
        return allFolders;
    }

	public static async updateFolder(id: string, data: { name: string, color: string }): Promise<void> {
		let folders = await this.getFolders();
		
		const updateInTree = (list: FolderData[]) => {
			for (const f of list) {
				if (f.id === id) {
					f.name = data.name;
					f.color = data.color;
					return true;
				}
				if (f.children && updateInTree(f.children)) return true;
			}
			return false;
		};

		updateInTree(folders);
		await this.saveFolders(folders);
	}	

	static async deleteFolder(id: string): Promise<FolderData[]> {
        const folders = await this.getFolders();
        const removeNode = (list: FolderData[]): FolderData[] => {
            return list
                .filter(f => f.id !== id)
                .map(f => ({
                    ...f,
                    children: removeNode(f.children || [])
                }));
        };
        const updated = removeNode(folders);
        await this.saveFolders(updated);
        return updated;
    }

	/**
	 * src/models/FolderManager.ts
	 * Recursive Reorder Supporting Cross-level Moves
	 */
	static async reorder(
		draggedId: string, 
		targetId: string, 
		position: 'before' | 'after' | 'inside',
	): Promise<FolderData[]> {
		const folders = await this.getFolders();
		let draggedNode: FolderData | null = null;

		// Detach: Recursive helper to remove the node
		const detach = (list: FolderData[]): void => {
			for (let i = 0; i < list.length; i++) {
				const current = list[i];
				if (!current) continue; // TS Guard

				if (current.id === draggedId) {
					const removed = list.splice(i, 1);
					if (removed.length > 0) {
						draggedNode = removed[0]!; // ! tells TS: we know it exists
					}
					return;
				}
				if (current.children) detach(current.children);
			}
		};

		detach(folders);
		if (!draggedNode) return folders;

		// Local reference to help TS inference
		const movingNode = draggedNode;

		// Attach: Recursive helper to insert the node
		const attach = (list: FolderData[], parentId: string | null = null): boolean => {
			const idx = list.findIndex(f => f.id === targetId);
			
			if (idx !== -1) {
				const targetNode = list[idx];
				if (!targetNode) return false; // TS Guard

				const nodeToInsert = movingNode as FolderData;

				if (position === 'inside') {
					targetNode.children = targetNode.children || [];
					nodeToInsert.parentId = targetNode.id;
					targetNode.children.push(movingNode);
				} else {
					nodeToInsert.parentId = parentId;
					const insertAt = position === 'before' ? idx : idx + 1;
					list.splice(insertAt, 0, movingNode);
				}
				return true;
			}

			for (const f of list) {
				if (f.children && attach(f.children, f.id)) return true;
			}
			return false;
		};

		attach(folders, null);
		await this.saveFolders(folders);
		return folders;
	}

    private static findAndAddChild(list: FolderData[], parentId: string, newNode: FolderData): boolean {
        for (const folder of list) {
            if (folder.id === parentId) {
                folder.children = folder.children || [];
                folder.children.push(newNode);
                return true;
            }
            if (folder.children && this.findAndAddChild(folder.children, parentId, newNode)) return true;
        }
        return false;
    }

	/**
	 * Injects a chat log as a bottom-level leaf node into a target parent folder.
	 * @param parentId - The target folder ID where the chat will be inserted.
	 * @param chat - Raw identifier and title extracted from the sidebar adapter.
	 */
	// static async saveChatToFolder(parentId: string, chat: { id: string; title: string }): Promise<FolderData[]> {
	// 	const folders = await this.getFolders();

	// 	// Generate a leaf node with a unique prefixed identifier
	// 	const chatNode: FolderData = {
	// 		id: `chat-${chat.id}`,
	// 		name: chat.title,
	// 		icon: '💬',
	// 		color: '#888888', // Neutral layout color for chat items
	// 		parentId: parentId,
	// 		children: [], // Leaf nodes cannot hold subcontainers
	// 		items: [],
	// 		isChat: true,
	// 		chatId: chat.id
	// 	};

	// 	const insertChatNode = (list: FolderData[]): boolean => {
	// 		for (const folder of list) {
	// 			if (folder.id === parentId) {
	// 				folder.children = folder.children || [];
					
	// 				// Avoid duplicating the same chat item within the exact same folder
	// 				const exists = folder.children.some(child => child.id === chatNode.id);
	// 				if (!exists) {
	// 					folder.children.push(chatNode);
	// 				}
	// 				return true;
	// 			}
	// 			if (folder.children && insertChatNode(folder.children)) {
	// 				return true;
	// 			}
	// 		}
	// 		return false;
	// 	};

	// 	insertChatNode(folders);
	// 	await this.saveFolders(folders);
	// 	return folders;
	// }

	/**
     * Saves a chat record as a leaf node under the specified parent folder.
     * Prevents duplicate entries within the same folder.
     */
    static async saveChatToFolder(parentId: string, chat: { id: string; title: string }): Promise<FolderData[]> {
        const folders = await this.getFolders();

        const chatNode: FolderData = {
            id: `chat-${chat.id}`,
            name: chat.title,
            icon: '💬',
            color: '#888888',
            parentId: parentId,
            children: [],
            items: [],
            isChat: true,
            chatId: chat.id
        };

        const insertChatNode = (list: FolderData[]): boolean => {
            for (const folder of list) {
                if (folder.id === parentId) {
                    folder.children = folder.children || [];

                    // Avoid duplicates within the same folder
                    const exists = folder.children.some(child => child.id === chatNode.id);
                    if (!exists) {
                        folder.children.push(chatNode);
                    }
                    return true;
                }
                if (folder.children && insertChatNode(folder.children)) {
                    return true;
                }
            }
            return false;
        };

        insertChatNode(folders);
        await this.saveFolders(folders);
        return folders;
    }

 	/**
     * Deletes a node (folder or chat leaf) from the tree.
     * @param id - The unique identifier of the node to delete.
     * @param parentId - If provided, only deletes the child node belonging to this parent.
     *                   Used for deleting chat records from a specific folder.
     * @returns The updated folder tree.
     */
    static async deleteNode(id: string, parentId?: string): Promise<FolderData[]> {
        const folders = await this.getFolders();

        const removeNode = (list: FolderData[]): FolderData[] => {
            return list
                .filter(f => {
                    // If it's a chat leaf and parentId is provided, match both id and parentId
                    if (f.isChat && parentId) {
                        return !(f.id === id && f.parentId === parentId);
                    }
                    // Otherwise, delete by id (folders or any matching chat)
                    return f.id !== id;
                })
                .map(f => ({
                    ...f,
                    children: removeNode(f.children || [])
                }));
        };

        const updated = removeNode(folders);
        await this.saveFolders(updated);
        return updated;
    }
}