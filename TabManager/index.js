var config = {
    "storage_tab_key" : "tm.tabs.",
    "storage_group_key" : "tm.group",
    "storage_tab_key_prefix" : "tm.tabs.prefix"
}

// var storageSupporter = {
//     saveTab: setToStorage  
// }

function setToStorage(keys, values) {

    var saveObj = {};
    for(var i = 0; i < keys.length; i++) {
        saveObj[keys[i]] = values[i];
    }

    browser.storage.sync.set(saveObj).then(() => {
        alert("saved!!");
    }, onError);
}

function getStorageTabKey(grpCd) {
    return config.storage_tab_key_prefix + "_" + grpCd;
}

function onError(error) {
    alert(error);
}

//document.body.style.border = "5px solid red";
