var startFinalFolderCore = require ('./FinalFolderCore/FinalFolderCoreStart.jsx');
var startFFListCore = require ('./FFListCore/FFListCoreStart.jsx');
var startMainMenuCore = require('./MainMenuCore/MainMenuCore.jsx');
var startRegisterCore = require('./RegisterCore/RegisterCoreStart.jsx');
var startMarkaDictionaryCore = require('./MarkaDictionaryCore/MarkaDictionaryCore.jsx');
var startTitleObjectDictionaryCore = require('./TitleObjectDictionaryCore/TitleObjectDictionaryCore.jsx');
var startFileStorageCore = require('./FileStorageCore/FileStorageCoreStart.jsx');
var startLineIsoCore = require('./LineIsoCore/LineIsoCore.jsx');
var startABDDocumentCore = require('./ABDDocumentCore/ABDDocumentCore.jsx');

//COMMENT THIS LINE WHEN THE FILE IS SENT TO WEBPACK - there is no need to apply testing objects to production
var startTestingEnvironment = require('./TestObjects/TestAsyncSelect.jsx');

module.exports = {
    runMainMenu: function runMainMenu(isAuth) {
        startMainMenuCore.startPage(isAuth);
    },  
    runFinalFolderList: function runFinalFolderList() {
        startFFListCore.startPage();
    },
    runFinalFolder: function runFinalFolder(ABDFinalFolder_ID) {
        if(ABDFinalFolder_ID) ABDFinalFolder_ID=ABDFinalFolder_ID.toLowerCase();
        startFinalFolderCore.startPage(ABDFinalFolder_ID);
    },
    runRegister: function runRegister(){
        startRegisterCore.startPage();
    },
    runMarkaDictionary: function runMarkaDictionary(){
        startMarkaDictionaryCore.startPage();
    },
    runTitleObjectDictionary: function runTitleObjectDictionary(){
        startTitleObjectDictionaryCore.startPage();
    },
    runFileStorage: function runFileStorage() {
        startFileStorageCore.startPage();
    },
    runLineIso: function runLineIso(){
        startLineIsoCore.startPage();
    },
    runABDDocument: function runABDDocument(){
        startABDDocumentCore.startPage();
    }
};

//THESE LINES ARE FOR TESTING PAGES VIA NODE.JS
//startRegisterCore.startPage();
//startTestingEnvironment.startPage();
//startFinalFolderCore.startPage("913ec043-99e9-e711-a9a5-0050569403d4");
//startFFListCore.startPage();
//startMainMenuCore.startPage();
//startMarkaDictionaryCore.startPage();
//startTitleObjectDictionaryCore.startPage();
//startFileStorageCore.startPage();
//startLineIsoCore.startPage();
//startABDDocumentCore.startPage();
