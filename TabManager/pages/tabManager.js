
(function() {
    browser.storage.sync.get("home-tabs").then((tabs) => {

        // alert(JSON.stringify(tabs["home-tabs"]));

        var tabList = document.querySelector("#tab-list");
        var li = "<ul>";

        for(var tab of tabs["home-tabs"]) {
            li = li + "<li><a href=" + tab.url + ">" + tab.title + "</a></li>";
        }
        li = li + "</ul>";

        tabList.innerHTML = li;
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