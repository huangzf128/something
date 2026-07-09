/**
 * Main Layout Components
 */
export const LayoutStyles = `
    .aichat-panel {
        position: fixed;
        right: -320px;
        top: 0;
        width: 320px;
        height: 100%;
        background-color: #171717;
        z-index: 10001;
        transition: right 0.3s cubic-bezier(0.4, 0, 0.2, 1);
        padding: 20px;
        box-sizing: border-box;
        border-left: 1px solid #333;
        font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, sans-serif;
    }
    .aichat-panel.is-open { right: 0; }


	/* ------------------------------ */
    /* --- Header & Buttons --- */
	/* ------------------------------ */
	.aichat-header {
		display: flex;
		justify-content: space-between;
		align-items: center;
		margin-bottom: 20px;
		padding-bottom: 10px;
		border-bottom: 1px solid #333;
	}
	
    .aichat-header-btn {
        cursor: pointer;
        padding: 4px 8px;
        border-radius: 4px;
        transition: background 0.2s;
        font-size: 18px;
        color: #888;
        display: flex;
        align-items: center;
    }
    .aichat-header-btn:hover {
        background: #333;
        color: #fff;
    }
	
	/* ------------------------------ */
    /* ---        dock        --- */
	/* ------------------------------ */
    .aichat-dock-trigger {
        position: fixed;
        right: 0;
        top: 50%;
        transform: translateY(-50%);
        width: 10px;
        height: 60px;
        background-color: #10a37f;
        cursor: pointer;
        z-index: 10000;
        border-radius: 10px 0 0 10px;
        transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
        box-shadow: -2px 0 8px rgba(0,0,0,0.2);
    }

    .aichat-dock-trigger:hover {
        width: 20px;
        background-color: #1a7f64;
    }

    .aichat-dock-trigger.is-hidden {
        right: -30px;
        opacity: 0;
        pointer-events: none;
    }
`;