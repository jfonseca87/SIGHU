$(document).ready(function () {

    table = $("#table").dataTable({
        ordering: false,
        searching: false,
        language: {
            processing: "Procesando...",
            lengthMenu: "Mostrando _MENU_ Registros",
            info: "",
            infoEmpty: "No hay registros",
            infoPostFix: "",
            loadingRecords: "Cargando...",
            zeroRecords: "No hay registros",
            paginate: {
                previous: "",
                next: "",
            },
        },
        destroy : true
    });

    $("#btnAdjuntos").click(function () {
        
        $("#modal1").modal("show");
        $(".cuerpo").load($(this).data("ruta") + "/Adjunto/NuevoAdjunto/"+ $(this).data("id"));
    });

    $("#ddGrupos").change(function () {
        var grupo = $(this).val();
        $("#IdTipoAdjunto").empty();
        $("#IdTipoAdjunto").append('<option value=""> Seleccione... </option>');

        $.ajax({
            url: $("#ruta").data("ruta") + "/Adjunto/consTipoAdjuntos/",
            data: { id: grupo },
            datatype: "json",
            type: "POST",
            success: function (data) {
                $("#IdTipoAdjunto").empty();
                $("#IdTipoAdjunto").append('<option value=""> Seleccione... </option>');
                $.each(data, function (i, item) {
                    $("#IdTipoAdjunto").append('<option value='+ item.IdTAdjunto + '>' + item.Nombre
                    + '</option>');
                });
            },
            fail: function (mensaje) {
                alert("Ha ocurrido un error contacte con el departamento de Sistemas!!!");
            }
        });
    });

    $("#RutaAdjunto").change(function () {
        var archivo = $(this).val().split('.');
        var extension = archivo[1];

        if (extension != 'pdf') {
            $("#btnGuardaAdjunto").attr("disabled", true);
            alert("Cargue unicamente archivos PDF");
        }
        else
        {
            $("#btnGuardaAdjunto").attr("disabled", false);
        }

    });

    $(".cmbPassword").click(function () {
        $("#modal1").modal("show");
        $(".cuerpo").load($(this).data("ruta") + "/Usuario/cambiaPassword/" + $(this).data("id"));
    });

    $(".password").click(function () {
        $("#modal1").modal("show");
        $(".cuerpo").load($(this).data("ruta") + "/Home/cambiaPassword/" + $(this).data("id"));
    });

    $("#Actual").click(function () {
        if ($(this).is(":checked")) {
            $("#AniosExpLab").attr("disabled", true);
        }
        else
        {
            $("#AniosExpLab").attr("disabled", false);
        }
    });

    $("#cambiaFoto").click(function () {
        $("#modal1").modal("show");
        $(".cuerpo").load($(this).data("ruta") + "/Persona/CambiaFoto/" + $(this).data("id"));
    })
    
    $("#RImagen").change(function () {
        var archivo = $(this).val().split('.');
        var extension = archivo[1];

        if (extension != 'jpg') {
            $("#btnGuardaImagen").attr("disabled", true);
            alert("Cargue unicamente imagenes con formato JPG");
        }
        else {
            $("#btnGuardaImagen").attr("disabled", false);
        }
    });
});