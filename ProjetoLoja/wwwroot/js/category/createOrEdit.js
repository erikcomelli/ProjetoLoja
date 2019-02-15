$(function () {
    SetBtnAddCategoryText();
});

function SetBtnAddCategoryText() {        
    if ($("#hdnId").val()!=="")
        $("#btnAddCategoryText").text("Atualizar");    
}