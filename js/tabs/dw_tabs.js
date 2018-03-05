/*************************************************************************
    This code is from Dynamic Web Coding at dyn-web.com
    Copyright 2009-10 by Sharon Paine 
    See Terms of Use at www.dyn-web.com/business/terms.php
    regarding conditions under which you may use this code.
    This notice must be retained in the code as is!
*************************************************************************/

// requires: dw_event.js, dw_cookies.js (2009 version)

function dw_Tabs(tabsetId, bUseCookies) {
    this.id = tabsetId; this.useCookies = bUseCookies;
    dw_Tabs.col[tabsetId] = this;
    this.init(tabsetId);
}

dw_Tabs.prototype = {
    current: null, // index value of currently active tab
    on_tab_select: function(){},

    init: function(tabsetId) {
        if ( !document.getElementById(tabsetId) ) {
            return;
        }
        var sel, dflt, cur, tabLinks, paneId, c, q, selPaneId, dfltPaneId, curPaneId;
        tabLinks = dw_Tabs.getTabs(tabsetId);
        q = parseInt( dw_Util.getValueFromQueryString(tabsetId) );
        if (this.useCookies) {
            c = parseInt( dw_Tabs.checkCookie(tabsetId) );
        }
        // tab in url or cookie?
        var sel = (!isNaN(q) && tabLinks[q])? q: (!isNaN(c) && tabLinks[c])? c: null;
        for (var i=0; tabLinks[i]; i++) {
            paneId = null; // reset
            tabLinks[i].id = tabsetId + '__' + i; // double underscore between
            paneId = tabLinks[i].hash.slice(1);
            if (paneId) { // if tab associated with tabpane, set up onclick fn
                dw_Event.add( tabLinks[i], 'click', dw_Tabs.showClicked );
            }
            // Find first tab with pane to hold defaults (if no tab in url or cookie or current)
            if ( !dfltPaneId && paneId ) {
                dfltPaneId = paneId;
                dflt = i;
            }
            // if set active in markup, hold as current
            if ( dw_Util.hasClass(tabLinks[i], 'activeTab') && 
                dw_Util.hasClass(document.getElementById( paneId ), 'activePane') ) {
                curPaneId = paneId;
                this.current = cur = i;
            }
            // be sure cookie or url specifies tab with pane (in case changes)
            if ( i === sel && paneId ) {
                selPaneId = paneId;
            }
        }
        
        if ( selPaneId ) { // tab selected in url or cookie?
            if ( curPaneId && curPaneId != selPaneId ) {
                dw_Tabs.hideCurrent(tabsetId, cur);
            }
            // set in markup?
            if ( !dw_Util.hasClass( tabLinks[sel], 'activeTab') ) {
                dw_Util.addClass( tabLinks[sel], 'activeTab');
            }
            if ( !dw_Util.hasClass( document.getElementById( selPaneId ), 'activePane') ) {
                dw_Util.addClass( document.getElementById( selPaneId ), 'activePane');
            }
            this.current = sel;
        } else if ( !curPaneId && dfltPaneId ) { // first tab with pane
            dw_Util.addClass( tabLinks[dflt], 'activeTab');
            dw_Util.addClass( document.getElementById( dfltPaneId ), 'activePane');
            this.current = dflt;
        }
    }

}

dw_Tabs.col = {};

dw_Tabs.hasBrowserSupport = function () {
    if ( document.getElementById && document.getElementsByTagName 
         && typeof decodeURI !== 'undefined'
         && (document.addEventListener || document.attachEvent) ) {
        return true;
    }
    return false;
}

dw_Tabs.getTabs = function (tabsetId) {
    // get the links in ul.tabnavs inside tabsetId
    var tabnavs = dw_Util.getElementsByClassName( 'tabnavs', 'ul', document.getElementById(tabsetId) );
    var tabLinks = tabnavs[0].getElementsByTagName('a');
    return tabLinks;
}

// last 3 args for use when called from event handler attr
dw_Tabs.showClicked = function(e, paneId, tabsetId, tabIdx) {
    var tabId = '';
    if (e) {
        var tgt = dw_Event.getTarget(e); 
        tabId = tgt.id;
        paneId = tgt.hash.slice(1);
        // extract tabset id from target's id and use it to obtain instance ...
        var ar = tabId.split('__');
        tabsetId = ar[0];
        tabIdx = ar[1]; // index value of tab
    } else {
        tabId = tabsetId + '__' + tabIdx;
    }
    var _this = dw_Tabs.col[tabsetId];
    dw_Tabs.hideCurrent(tabsetId, _this.current);
    dw_Util.addClass( document.getElementById(tabId), 'activeTab');
    dw_Util.addClass(document.getElementById(paneId), 'activePane');
    _this.current = tabIdx;
    
    if ( _this.useCookies ) {
        dw_Tabs.setCookie(tabsetId, tabIdx);
    }
    _this.on_tab_select(tabId);
    if (e) {
        e.preventDefault();
    }
    return false;
}

dw_Tabs.hideCurrent = function(tabsetId, cur) {
    var tabId = tabsetId + '__' + cur;
    var tabLinks = dw_Tabs.getTabs(tabsetId);
    var paneId = (tabLinks[cur]).hash.slice(1);
    dw_Util.removeClass( document.getElementById(tabId), 'activeTab');
    dw_Util.removeClass(document.getElementById(paneId), 'activePane');
}

dw_Tabs.checkCookie = function(tabsetId) {
    var c, cookies, tab_cookies = dw_Cookie.get('dw_Tabs');
    if ( tab_cookies ) {
        cookies = tab_cookies.split(',');
        for (var i=0; cookies[i]; i++) {
            c = cookies[i];
            if ( c.indexOf(tabsetId + ':') === 0 ) {
                return decodeURI( c.slice(tabsetId.length + 1, c.length) );
            }
        }
    }
    return null;
}

dw_Tabs.setCookie = function(tabsetId, tabIdx) {
    // format for cookies (multiple tabsets supported): dw_Tabs=tabsetId:tabIdx,tabsetId:tabIdx;
    var new_tab_cookies = '', cookies;
    var tab_cookies = dw_Cookie.get('dw_Tabs');
    if ( tab_cookies ) {
        cookies = tab_cookies.split(',');
        for (var i=0; cookies[i]; i++) {
            if ( cookies[i].indexOf(tabsetId + ':') === 0 ) {
                cookies[i] = tabsetId + ':' + tabIdx;
                new_tab_cookies = cookies.join(',');
                break;
            }
        }
        if ( !new_tab_cookies ) { // if no match for this tabsetId
            new_tab_cookies = tab_cookies + ',' + tabsetId + ':' + tabIdx;
        }
    } else { // no dw_Tabs set yet
        new_tab_cookies = tabsetId + ':' + tabIdx;
    }
    dw_Cookie.set('dw_Tabs', new_tab_cookies, null, '/');
}

/////////////////////////////////////////////////////////////////////
//  utility functions

var dw_Util; 
if (!dw_Util) dw_Util = {};

dw_Util.trimString = function (str) {
    var re = /^\s+|\s+$/g;
    return str.replace(re, "");
}

dw_Util.normalizeString = function (str) {
    var re = /\s\s+/g;
    return dw_Util.trimString(str).replace(re, " ");
}

dw_Util.addClass = function (el, cl) {
    el.className = dw_Util.trimString( el.className + ' ' + cl );
}

dw_Util.removeClass = function (el, cl) {
    el.className = dw_Util.normalizeString( el.className.replace(cl, " ") );
}

dw_Util.hasClass = function (el, cl) {
    var re = new RegExp("\\b" + cl + "\\b", "i");
    if ( re.test( el.className ) ) {
        return true;
    }
    return false;
}

// what className attached to what element type in what container element (default: document)
dw_Util.getElementsByClassName = function (sClass, sTag, oCont) {
    var result = [], list, i;
    var re = new RegExp("\\b" + sClass + "\\b", "i");
    oCont = oCont? oCont: document;
    if ( document.getElementsByTagName ) {
        if ( !sTag || sTag == "*" ) { // for ie5
            list = oCont.all? oCont.all: oCont.getElementsByTagName("*");
        } else {
            list = oCont.getElementsByTagName(sTag);
        }
        for (i=0; list[i]; i++) 
            if ( re.test( list[i].className ) ) result.push( list[i] );
    }
    return result;
}

// obj: link or window.location
dw_Util.getValueFromQueryString = function (name, obj) {
    obj = obj? obj: window.location; 
    if (obj.search && obj.search.indexOf(name != -1) ) {
        var pairs = obj.search.slice(1).split("&"); // name/value pairs
        var set;
        for (var i=0; pairs[i]; i++) {
            set = pairs[i].split("="); // Check each pair for match on name 
            if ( set[0] == name && set[1] ) {
                return set[1];
            }
        }
    }
    return '';
}

// Alternate functions are available that use DOM methods instead of document.write
dw_Util.writeStyleSheet = function(file, bScreen) {
    var screen = (bScreen != false)? '" media="screen" />\n': '"/>\n';
    document.write( '\n<link rel="stylesheet" href="' + file + screen);
}

// used to set min-height (as on dyn-web home page)
dw_Util.writeStyleRule = function(rule, bScreen) {
    var screen = (bScreen != false)? ' media="screen">': '>';
    document.write( '\n<style type="text/css"' + screen + rule + '</style>');
}