﻿var pbControl = null;
var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_beginRequest(BeginRequestHandler);
prm.add_endRequest(EndRequestHandler);
function BeginRequestHandler(sender, args) {
    pbControl = args.get_postBackElement();  //the control causing the postback
    pbControl.disabled = true;
    var upnlID = sender._postBackSettings.panelID.split('|')[0];
    upnlID = upnlID.replace(/\$/gi, '_');
    onUpdatingPanel(upnlID);
}
function EndRequestHandler(sender, args) {
    pbControl.disabled = false;
    if (sender != null && sender._postBackSettings != null && sender._postBackSettings.panelID != null) {
        var upnlID = sender._postBackSettings.panelID.split('|')[0];
        upnlID = upnlID.replace(/\$/gi, '_');
        onUpdatedPanel(upnlID);
    }
}
function onUpdatingPanel(upnlID) {    
    // get the update progress div
    var updateProgressDiv = $get('ctl00_upAjaxUpdate');
 
    if (updateProgressDiv != null) {
        //get the updatePanel element
        var updatePanel = $get(upnlID);
 
        // get the bounds of both the updatePanel and the progress div
        var updatePanelBounds = Sys.UI.DomElement.getBounds(updatePanel);
 
        //set the progress element to this position
        var divLoading = updateProgressDiv.getElementsByTagName('div')[0];
        divLoading.style.width = updatePanelBounds.width;
        divLoading.style.height = updatePanelBounds.height;
        var imgLoading = updateProgressDiv.getElementsByTagName('img')[0];
        imgLoading.style.marginTop = updatePanelBounds.height / 2;
        Sys.UI.DomElement.setLocation(updateProgressDiv, updatePanelBounds.x, updatePanelBounds.y);
        // make it visible
        updateProgressDiv.style.display = 'block';
    }
}
function onUpdatedPanel(upnlID) {
    // get the update progress div
    var updateProgressDiv = $get('ctl00_upAjaxUpdate');
    // make it invisible
    if (updateProgressDiv != null) {
        updateProgressDiv.style.display = 'none';
    }
}
 
