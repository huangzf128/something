/**
 * src/ui/RightSidebar.ts
 * Manages the folder tree UI, sidebar interactions, and drag-and-drop orchestration.
 */
import { FolderManager } from '../models/FolderManager';
import { FolderEditor } from './FolderEditor';
import { ICONS } from './icons';
import { GlobalStyles } from '../ui/styles/index';
import type { FolderData } from '../models/Folder';

export class RightSidebar {
    private panel: HTMLElement | null = null;
    private dock: HTMLElement | null = null;

    constructor() {
        this.init();
    }

    private async init(): Promise<void> {
        this.injectStyles();
        this.createDockTrigger();
        this.createPanel();
		this.bindDragEvents();

        await this.refresh();
    }

	/**
     * Injects global CSS styles into the document head.
     */
    private injectStyles(): void {
        if (document.getElementById('aichat-styles')) return;
        const style = document.createElement('style');
        style.id = 'aichat-styles';
        style.textContent = GlobalStyles;
        document.head.appendChild(style);
    }

	/**
     * Creates the floating handle used to open the sidebar.
     */
    private createDockTrigger(): void {
        this.dock = document.createElement('div');
        this.dock.className = 'aichat-dock-trigger';
        this.dock.onclick = () => this.toggle(true);
        document.body.appendChild(this.dock);
    }

    private createPanel(): void {
        this.panel = document.createElement('div');
        this.panel.className = 'aichat-panel';
		this.panel.innerHTML = `
			<div class="aichat-header">
				<h2 style="color:white; margin:0; font-size:18px;">Folders</h2>
				<div style="display: flex; gap: 12px; align-items: center;">
					<div id="add-folder-root" class="aichat-header-btn" title="Add New Top-level Folder">
						${ICONS.ADD_FOLDER_HEADER}
					</div>
					<div id="aichat-close-btn" class="aichat-header-btn" title="Close">
						${ICONS.CLOSE}
					</div>
				</div>
			</div>
			<div id="aichat-folder-list"></div>
		`;
        document.body.appendChild(this.panel);
        this.bindGlobalEvents();
    }

	/**
     * Controls the visibility of the sidebar panel and the trigger handle.
     */
    public toggle(open: boolean): void {
        if (!this.panel || !this.dock) return;
        this.panel.classList.toggle('is-open', open);
        this.dock.classList.toggle('is-hidden', open);
    }

	/**
     * Binds UI interactions (click events) using event delegation on the panel.
     */
    private bindGlobalEvents(): void {

        this.panel?.addEventListener('click', async (e) => {
            const target = e.target as HTMLElement;
            
			if (target.closest('#aichat-close-btn')) {
				this.toggle(false);
				return;
			}

            if (target.closest('#add-folder-root')) {
                this.showEditor(null);
            }

			const editBtn = target.closest('.edit-btn') as HTMLElement;
			if (editBtn) {
				const id = editBtn.dataset.id!;
				const folders = await FolderManager.getFolders();
				
				const folderToEdit = this.findFolderById(folders, id);
				
				if (folderToEdit) {
					this.showEditor(folderToEdit.parentId || null, folderToEdit);
				}
			}

            const addSub = target.closest('.add-sub-btn') as HTMLElement;
            if (addSub) {
                this.showEditor(addSub.dataset.id!);
            }

            const delBtn = target.closest('.delete-btn') as HTMLElement;
            if (delBtn) {
                const id = delBtn.dataset.id!;
                if (confirm('Delete this folder and all sub-folders?')) {
                    const updated = await FolderManager.deleteFolder(id);
                    this.render(updated);
                }
            }

			const toggleBtn = target.closest('.toggle-btn') as HTMLElement;
			if (toggleBtn) {
				e.stopPropagation();
				const id = toggleBtn.dataset.id!;
				const node = toggleBtn.closest('.aichat-folder-node') as HTMLElement;
				
				if (node) {
					const isCollapsed = node.classList.toggle('is-collapsed');
					const folders = await FolderManager.getFolders();
					const updateStatus = (list: FolderData[]) => {
						for (const f of list) {
							if (f.id === id) {
								f.isCollapsed = isCollapsed;
								return true;
							}
							if (f.children && updateStatus(f.children)) return true;
						}
						return false;
					};

					updateStatus(folders);
					await FolderManager.saveFolders(folders);
				}
				return;
			}
        });

		window.addEventListener('aichat:save-to-folder', async (e: Event) => {
			const customEvent = e as CustomEvent<{ folderId: string; chatInfo: { id: string; title: string } }>;
			const { folderId, chatInfo } = customEvent.detail;

			if (!folderId || !chatInfo) return;

			// Save directly under current single platform logic
			await FolderManager.saveChatToFolder(folderId, chatInfo);
			await this.refresh();
		});	

    }

	/**
	 * Recursively finds a folder by its ID within a tree structure.
	 * @param folders - The array of folders to search.
	 * @param id - The target folder ID.
	 * @returns The found FolderData or null.
	 */
	private findFolderById(folders: FolderData[], id: string): FolderData | null {
		for (const folder of folders) {
			if (folder.id === id) return folder;
			if (folder.children && folder.children.length > 0) {
				const found = this.findFolderById(folder.children, id);
				if (found) return found;
			}
		}
		return null;
	}

	/**
     * Renders the folder list into the DOM container.
     */
    public render(folders: FolderData[]): void {
        const list = document.getElementById('aichat-folder-list');
        if (!list) return;

        const rootFolders = folders.filter(f => !f.parentId);
        list.innerHTML = this.renderFolderTree(rootFolders, 0);
    }

	/**
     * Recursively generates the HTML string for the folder tree.
     */
    // private renderFolderTree(folders: FolderData[], level: number): string {
    //     return folders.map(folder => {
	// 		const hasChildren = folder.children && folder.children.length > 0;
	// 		const collapseClass = folder.isCollapsed ? 'is-collapsed' : '';

	// 		return `
    //         <div class="aichat-folder-node ${collapseClass}">
    //             <div class="aichat-folder-card" data-id="${folder.id}" draggable="true"
    //                  style="border-left: 4px solid ${folder.color};">
    //                 <div class="aichat-folder-header">
    //                     <span class="aichat-folder-title">
    //                         <span class="aichat-folder-icon colored" style="--glow-color: ${folder.color};">
    //                             ${ICONS.FOLDER}
    //                         </span>
    //                         <span>${folder.name} (${folder.items?.length || 0})</span>
    //                     </span>
    //                     <div class="aichat-actions">
	// 						<span class="edit-btn" data-id="${folder.id}">${ICONS.EDIT}</span>
    //                         <span class="add-sub-btn" data-id="${folder.id}">${ICONS.PLUS}</span>
    //                         <span class="delete-btn" data-id="${folder.id}">${ICONS.TRASH}</span>
	// 						${hasChildren ? `<span class="toggle-btn" data-id="${folder.id}">${ICONS.CHEVRON_DOWN}</span>` : ''}												
    //                     </div>
    //                 </div>
    //             </div>
    //             <div class="aichat-sub-container" id="children-of-${folder.id}">
    //                 ${this.renderFolderTree(folder.children || [], level + 1)}
    //             </div>
    //         </div>
    //     `}).join('');
    // }

	
	private showEditor(parentId: string | null, existingData?: FolderData): void {
		let container: HTMLElement | null;
		let referenceNode: Node | null = null;

		if (existingData) {
			// 💡 Edit mode: find the node containing the current card
			const card = this.panel?.querySelector(`.aichat-folder-card[data-id="${existingData.id}"]`);
			const node = card?.closest('.aichat-folder-node') as HTMLElement;
			container = node?.parentElement as HTMLElement;
			referenceNode = node; // We'll insert at the current node's position
		} else {
			// 💡 Create mode: original logic
			container = parentId 
				? document.getElementById(`children-of-${parentId}`) 
				: document.getElementById('aichat-folder-list');
			referenceNode = container?.firstChild || null;
		}

		if (!container || container.querySelector('.aichat-edit-card')) return;

		const form = FolderEditor.render(
			() => this.refresh(),
			() => { 
				form.remove();
				// If you hid the original card during editing, remember to show it back here
				if (existingData) {
					(referenceNode as HTMLElement).style.display = 'block';
				}
			},
			parentId,
			existingData
		);

		// 💡 Edit mode: optionally hide the original node first, then insert the editor
		if (existingData && referenceNode) {
			(referenceNode as HTMLElement).style.display = 'none';
			container.insertBefore(form, referenceNode);
		} else {
			container.insertBefore(form, referenceNode);
		}
	}

	/**
     * Fetches fresh folder data and triggers a re-render.
     */
    public async refresh(): Promise<void> {
        const folders = await FolderManager.getFolders();
        this.render(folders);
    }

	/**
     * Binds Drag and Drop events to the main panel using Event Delegation.
     * This ensures events are persistent even after innerHTML updates.
     */
	private bindDragEvents(): void {
		let draggedId: string | null = null;
		let lastPotentialNode: HTMLElement | null = null;
		let currentTargetNode: HTMLElement | null = null;
		let dragEnterTimer: number | null = null;

		/**
         * Clears visual drag indicators from the DOM.
         */
		const clearStyles = () => {
			this.panel?.querySelectorAll('.has-drop-before').forEach(n => 
				n.classList.remove('has-drop-before'));
			this.panel?.querySelectorAll('.drop-inside').forEach(c => 
				c.classList.remove('drop-inside'));	
			this.panel?.querySelectorAll('[data-drop-pos]').forEach(n => {
					delete (n as HTMLElement).dataset.dropPos;
    			});				
		};

		/**
         * Resets DND state variables and cleans up UI.
         */
		const finalizeDrag = () => {
			if (dragEnterTimer) window.clearTimeout(dragEnterTimer);
            clearStyles();
            document.querySelectorAll('.dragging').forEach(el => el.classList.remove('dragging'));

            draggedId = null;
            lastPotentialNode = null;
            currentTargetNode = null;
		};

		// Start dragging the card
		this.panel?.addEventListener('dragstart', (e) => {
			const target = e.target as HTMLElement;
			const card = target.closest('.aichat-folder-card') as HTMLElement;
			if (!card) return;

			draggedId = card.dataset.id || null;
			card.classList.add('dragging');
			
			if (e.dataTransfer) {
				e.dataTransfer.effectAllowed = 'move';
				e.dataTransfer.setData('text/plain', draggedId || '');
			}
		});

		// Manage placeholder logic when entering a node
		this.panel?.addEventListener('dragenter', (e) => {

			const card = (e.target as HTMLElement).closest('.aichat-folder-card') as HTMLElement;
            if (!card) return;

            const node = card.closest('.aichat-folder-node') as HTMLElement;
            if (!node || node === lastPotentialNode) return;

			// Prevent self-dropping
            if (card.dataset.id === draggedId) return;

			// Get the dragging element's node (the one with 'dragging' class)
			const draggedNode = document.querySelector('.dragging')?.closest('.aichat-folder-node');

			// 💡 THE TRICK: If the dragged node CONTAINS the target node, it's an illegal move
			// (This covers both "self" and "descendants" in one simple check)
			if (draggedNode && node && draggedNode.contains(node)) {
				clearStyles();
				return;
			}

			// Neighbor optimization: skip if dragging right above the next node
			const draggedElement = document.querySelector('.dragging')?.closest('.aichat-folder-node');
			if (draggedElement && draggedElement.nextElementSibling === node) {
				clearStyles();
				lastPotentialNode = node;
				currentTargetNode = node;
				return;
			}

			lastPotentialNode = node;
			if (dragEnterTimer) window.clearTimeout(dragEnterTimer);

			// Debounce to prevent flickering during fast movements
			dragEnterTimer = window.setTimeout(() => {
				if (lastPotentialNode === node) {
					clearStyles();
					node.classList.add('has-drop-before');
					currentTargetNode = node;
				}
				dragEnterTimer = null;
			}, 100);
		});

		// Determine if user wants to drop BEFORE or INSIDE
		this.panel?.addEventListener('dragover', (e) => {
			e.preventDefault();
			if (!currentTargetNode) return;

			const card = currentTargetNode.querySelector('.aichat-folder-card') as HTMLElement;
			const rect = card.getBoundingClientRect();
			const relY = e.clientY - rect.top;
			const height = rect.height;

			const isInside = relY > height * 0.2 && relY < height * 0.8;
			const isAfter = relY >= height * 0.8;
			const isLast = !currentTargetNode.nextElementSibling;

			// Inside feedback
			card.classList.toggle('drop-inside', isInside);

			// After feedback: Only show if it's the last one in the current list
			if (isLast) {
				if (isAfter) {
					currentTargetNode.dataset.dropPos = 'after';
					currentTargetNode.classList.remove('has-drop-before');

				} else if (currentTargetNode.dataset.dropPos === 'after' && relY <= height * 0.2) {
					delete currentTargetNode.dataset.dropPos;
					currentTargetNode.classList.toggle('has-drop-before', relY <= height * 0.2);
				}
			}
		});

		// Perform data reordering on drop
		this.panel?.addEventListener('drop', async (e) => {
			e.preventDefault();
			
			const targetNode = currentTargetNode;
			const movingId = draggedId;
			
			if (!targetNode || !movingId) {
				finalizeDrag();
				return;
			}

			const card = targetNode.querySelector('.aichat-folder-card') as HTMLElement;
			const targetId = card?.dataset.id;
			const isInside = card?.classList.contains('drop-inside');
			const isAfter = targetNode.dataset.dropPos === 'after';

			// Cleanup UI immediately before async operation to lock interaction
			finalizeDrag(); 

			if (targetId && movingId !== targetId) {
				let position: 'before' | 'inside' | 'after' = 'before';
				if (isInside) position = 'inside';
				else if (isAfter) position = 'after';

				await FolderManager.reorder(movingId, targetId, position);
				
				// Refresh DOM after reorder completes
				window.requestAnimationFrame(() => {
					this.refresh();
				});
			}
		});

		// Global cleanup if drag is canceled
		this.panel?.addEventListener('dragend', () => {
			finalizeDrag();
		});

	}




	private renderFolderTree(folders: FolderData[], level: number): string {
		return folders.map(folder => {
			const hasChildren = folder.children && folder.children.length > 0;
			const collapseClass = folder.isCollapsed ? 'is-collapsed' : '';
			
			// 💡 Render specialized chat records for the current environment
			if (folder.isChat && folder.chatId) {
				// 💡 Correctly fetching url through the adapter mapping method we just exposed
				const resolver = (window as any).resolveCurrentChatUrl;
				const dynamicUrl = resolver ? resolver(folder.chatId) : '#';
				
				return `
				<div class="aichat-folder-node aichat-chat-leaf" data-id="${folder.id}">
					<div class="aichat-folder-card aichat-chat-card" data-id="${folder.id}" draggable="true"
						style="border-left: 3px solid rgba(255, 255, 255, 0.2); background: #1a1a1a; margin-left: ${level * 4}px;">
						<div class="aichat-folder-header" style="gap: 4px; display: flex; align-items: center; justify-content: space-between; width: 100%;">
							<span class="aichat-folder-title" style="flex: 1; min-width: 0; display: block;">
								<a href="${dynamicUrl}" class="aichat-chat-anchor" title="${folder.name}" target="_blank"
								style="color: #b3b3b3; text-decoration: none; font-size: 13px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; display: block; width: 100%;">
									${folder.name}
								</a>
							</span>
							<div class="aichat-actions" style="flex-shrink: 0; display: flex; align-items: center;">
								<span class="delete-btn" data-id="${folder.id}">${ICONS.TRASH}</span>
							</div>
						</div>
					</div>
				</div>
				`;
			}

			// Standard Folder HTML Template remains unchanged
			return `
			<div class="aichat-folder-node ${collapseClass}">
				<div class="aichat-folder-card" data-id="${folder.id}" draggable="true"
					style="border-left: 4px solid ${folder.color};">
					<div class="aichat-folder-header">
						<span class="aichat-folder-title">
							<span class="aichat-folder-icon colored" style="--glow-color: ${folder.color};">
								${ICONS.FOLDER}
							</span>
							<span>${folder.name}</span>
						</span>
						<div class="aichat-actions">
							<span class="edit-btn" data-id="${folder.id}">${ICONS.EDIT}</span>
							<span class="add-sub-btn" data-id="${folder.id}">${ICONS.PLUS}</span>
							<span class="delete-btn" data-id="${folder.id}">${ICONS.TRASH}</span>
							${hasChildren ? `<span class="toggle-btn" data-id="${folder.id}">${ICONS.CHEVRON_DOWN}</span>` : ''}												
						</div>
					</div>
				</div>
				<div class="aichat-sub-container" id="children-of-${folder.id}">
					${this.renderFolderTree(folder.children || [], level + 1)}
				</div>
			</div>
			`;
		}).join('');
	}	


}