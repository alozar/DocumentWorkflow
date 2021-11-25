$(function () {
    var docModal = new bootstrap.Modal($("#docModal"));
   
    $("#createOutgoingDoc").on("click", { docType: "Outgoing", action: "Create" }, showDocModal);
    $("#createIncomingDoc").on("click", { docType: "Incoming", action: "Create"  }, showDocModal);
    $("#docModalOkBtn").on("click", docOkClick);
    $("#docModalCloseBtn").on("click", docCloseClick);
    $("#changeStatusBtn").on("click", changeStatusModalClick);
    $("table").on("click", ".dw-details", docModalDetails);
    $("table").on("click", ".dw-next-status", nextStatusClick);
    $("table").on("click", ".dw-create-outgoing", { docType: "Outgoing" }, docModalCreate);//dependenceOutgoingDocModalCreate
    //function getPrivContractorJson(privContractorElem, isModal = false) {
    //    var fields = privContractorElem.find('input, select, textarea');
    //    var contractorJson = {};
    //    fields.each(function (idx, elem) {
    //        var name = $(elem).attr('id').split('_')[0];
    //        if (isModal) {
    //            name = $(elem).attr('id').split('_')[1];
    //        }
    //        if ($(elem).attr('type') == 'checkbox') {
    //            contractorJson[name] = $(elem).is(':checked');
    //        }
    //        else {
    //            contractorJson[name] = $(elem).val();
    //        }
    //    });
    //    return contractorJson;
    //}
    function errorAjax(jqXHR, textStatus, errorThrown) {
        console.log(jqXHR);
        console.log(textStatus);
        console.log(errorThrown);
    }

    function additionalFieldsHide(type) {
        var incoming = $(".dw-incoming");
        var outgoing = $(".dw-outgoing");
        if (type == "Outgoing") {
            incoming.hide();
            outgoing.show();
        }
        if (type == "Incoming") {
            incoming.show();
            outgoing.hide();
        }
    }

    function changeClassIcon(elemIcon, nameClass) {
        elemIcon.removeClass().addClass("fas " + nameClass);
    }

    function docModalFill(doc, status, type = "Incoming") {
        $("#docType").val(type);
        $("#docStatusEnum").val(status.name);
        $("#docStatusText").val(status.text);
        changeClassIcon($("#docStatusText").prev().children(), status.class);

        $("#docId").val(doc.Id);
        $("#docNumber").val(doc.number);
        $("#docDate").val(doc.date);
        $("#docContent").val(doc.content);

        $("#docApplicant").val(doc.applicant);
        $("#docAddressee").val(doc.addressee);
        $("#docTheme").val(doc.theme);
        $("#docSigner").val(doc.signer);
    }

    function docModalDetails(e) {
        e.preventDefault();
        var tr = $(this).closest('tr');
        var type = tr.data("type");
        $.ajax({
            type: "POST",
            url: window.location.origin + "/Documents/Details",
            data: {
                id: tr.data("id"),
                typeEnum: type
            },
            success: function (data) {
                console.log(data);
                additionalFieldsHide(type);
                docModalFill(data.doc, data.status, type);
                docModal.show();
            },
            error: errorAjax
        });
    }

    function showDocModal(e) {
        e.preventDefault();
        var type = e.data.docType;
        additionalFieldsHide(type);
        if (type == "") {
            docModalLabel.text();
        }
        docModal.show();
    }

    function docOkClick(e) {
        e.preventDefault();
        clearDocModal();
    }

    function clearDocModal() {
        $("#docModal form")[0].reset();
        var btn = $("#changeStatusBtn");
        changeClassIcon(btn.next().children(), "fa-registered");//iconStatus
        changeClassIcon(btn.children(), "fa-angle-double-right");
        $("#docStatusText").val("Зарегистрирован");
    }

    function docCloseClick(e) {
        e.preventDefault();
        clearDocModal();
    }

    function changeStatusModalClick(e) {
        e.preventDefault();
        var btn = $(this);
        var iconBtn = btn.children();
        var isNext = iconBtn.hasClass("fa-angle-double-right");
        var nameFunction = isNext ? "NextStatus" : "PrevStatus";
        $.ajax({
            type: "POST",
            url: window.location.origin + "/Documents/" + nameFunction,
            data: {
                statusEnum: $("#docModal #docStatusEnum").val(),
                typeEnum: $("#docModal #docType").val()
            },
            success: function (status) {
                $("#docStatusEnum").val(status.name);
                $("#docStatusText").val(status.text);
                changeClassIcon(btn.next().children(), status.class);//iconStatus
                if (isNext) {
                    changeClassIcon(iconBtn, "fa-angle-double-left");
                }
                else {
                    changeClassIcon(iconBtn, "fa-angle-double-right");
                }
            },
            error: errorAjax
        });
    }

    function nextStatusClick(e) {
        e.preventDefault();
        var tr = $(this).closest('tr');
        $.ajax({
            type: "POST",
            url: window.location.origin + "/Documents/NextStatusUpdate",
            data: {
                id: tr.data("id"),
                typeEnum: tr.data("type")
            },
            success: function (status) {
                console.log(status);
                var td = tr.find(".dw-status");
                td.attr("title", status.text);
                td.find("i").removeClass().addClass("fas " + status.class);
                tr.data("status", status.name);
                if (status.name == 'Archive') {
                    tr.find(".dw-next-status").addClass("disabled");
                }
            },
            error: errorAjax
        });
    }
})