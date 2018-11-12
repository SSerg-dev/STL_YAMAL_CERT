var Employee_ID = null;
var Callback_Employee_ID = null;
var Editor_Document_ID = null;
var Editor_Employee_ID = null;
var Editor_Document_IsTemplate = null;
var Editor_Shown = false;

function EmployeeList_RowClick(s, e) {
    OpenPersonDetails(EmployeeList.GetRowKey(e.visibleIndex));
}

function OpenPersonDetails(employeeID) {
    Employee_ID = employeeID;
    Callback_Employee_ID = employeeID;

    if (!PersonDetailsCbp.InCallback())
        PersonDetailsCbp.PerformCallback();
}

function PersonDetailsCbp_OnBeginCallback(s, e) {
    e.customArgs["Employee_ID"] = Callback_Employee_ID;
    Callback_Employee_ID = null;
}

function PersonDetailsCbp_OnEndCallback(s, e) {
    if (Callback_Employee_ID != null)
        PersonDetailsCbp.PerformCallback();
}

function OpenDocumentEditor(Employee_ID, Document_ID, isTemplate) {
    Editor_Employee_ID = Employee_ID;
    Editor_Document_ID = Document_ID;
    Editor_Document_IsTemplate = isTemplate;

    // popup tries to render with empty model if you call PerformCallback when showing it for the first time
    // TODO: figure out a proper way to call this
    //if (Editor_Shown) {
    DocumentEditPopup.PerformCallback();
    //}
    Editor_Shown = true;
}

function DocumentEditForm_AjaxOnComplete(data) {
    if (data.responseJSON === undefined) return;
    if (data.responseJSON.Success) {
        DocumentEditPopup.Hide();
        OpenPersonDetails(Employee_ID);
    };
}

function DocumentEditPopup_OnCancelClicked(s, e) {
    DocumentEditPopup.Hide();
}

function DocumentEditPopup_OnBeginCallback(s, e) {
    e.customArgs["Employee_ID"] = Editor_Employee_ID;
    e.customArgs["Document_ID"] = Editor_Document_ID;
    e.customArgs["isTemplate"] = Editor_Document_IsTemplate;
}


function DocumentEditPopup_OnEndCallback(s, e) {
    DocumentEditPopup.Show();
}

function EmployeeEditPopup_OnEndCallback(s, e) {
    EmployeeEditPopup.Show();
}

function EmployeeEditPopup_OnCancelClicked(s, e) {
    EmployeeEditPopup.Hide();
}

function EmployeeEditPopup_OnBeginCallback(s, e) {
    e.customArgs["Employee_ID"] = EmployeeEditPopup.Employee_ID;

}

function EmployeeEditPopup_Open(Employee_ID) {
    EmployeeEditPopup.Employee_ID = Employee_ID;
    EmployeeEditPopup.PerformCallback();
}

function EmployeeList_OnContextMenuItemClick(s, e) {    
    var Employee_ID = s.GetRowKey(e.elementIndex);

    if (e.item.name === "Edit") {
        e.handled = true;
        
        EmployeeEditPopup_Open(Employee_ID);
    }
}

function EmployeeList_OnToolbarItemClick(s, e) {

    if (e.item.name === "New") {
        e.handled = true;

        EmployeeEditPopup_Open(null);
    }

}

function EmployeeEditForm_AjaxOnComplete(data) {
    if (data.responseJSON === undefined) return;
    if (data.responseJSON.Success) {
        EmployeeEditPopup.Hide();
        EmployeeList.PerformCallback();
    };
}