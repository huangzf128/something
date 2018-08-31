var config = {
    "storage_tab_key" : "tabManager.tabs",
    "storage_group_key" : "tabManager.group"
}

// var storageSupporter = {
//     saveTab: setToStorage  
// }

function setToStorage(key, value) {
    var tabObj = {};
    tabObj[config.storage_tab_key] = targetTabs;

    browser.storage.sync.set(tabObj).then(() => {
        alert("saved!!");
    }, onError);

}

document.body.style.border = "5px solid red";
