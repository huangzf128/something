
(function() {
    browser.storage.sync.get(config.storage_tab_key).then((tabs) => {

        // alert(JSON.stringify(tabs));

        var tabList = document.querySelector("#tab-list");
        var tabHtml = "<ul>";

        for(var tab of tabs[config.storage_tab_key]) {
            tabHtml = tabHtml + "<li><a target='_blank' href=" + tab.url + ">" + tab.title + "</a></li>";
        }
        tabHtml = tabHtml + "</ul>";

        tabList.innerHTML = tabHtml;
    }, onError);
}());




function onError(error) {
    alert(error);
}

/* ----- trach code for study ------ */

// browser.runtime.onMessage.addListener(request => {
//     console.log(request.greeting);
//     return Promise.resolve({response: "Hi from content script"});
// });