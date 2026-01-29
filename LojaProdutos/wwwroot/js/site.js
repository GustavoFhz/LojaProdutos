// Aguarda o carregamento completo do DOM antes de executar o código
$(document).ready(function () {

    //Configuração JS - Filtros:

    $('#registros').DataTable({

        "ordering": true,

        "paging": true,

        "searching": true,

        "oLanguage": {

            "sEmptyTable": "Nenhum registro encontrado na tabela",

            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",

            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",

            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",

            "sInfoPostFix": "",

            "sInfoThousands": ".",

            "sLengthMenu": "Mostrar _MENU_ registros por pagina",

            "sLoadingRecords": "Carregando...",

            "sProcessing": "Processando...",

            "sZeroRecords": "Nenhum registro encontrado",

            "sSearch": "Pesquisar",

            "oPaginate": {

                "sNext": "Proximo",

                "sPrevious": "Anterior",

                "sFirst": "Primeiro",

                "sLast": "Ultimo"

            },

            "oAria": {

                "sSortAscending": ": Ordenar colunas de forma ascendente",

                "sSortDescending": ": Ordenar colunas de forma descendente"

            }

        }

    });


});



    // Define um atraso de 4000 milissegundos (4 segundos)
    setTimeout(function () {

        // Seleciona todos os elementos com a classe "alert"
        // e aplica um efeito de desaparecer lentamente
        $(".alert").fadeOut("slow", function () {

            // Após o fadeOut terminar, fecha o alerta
            // (método usado geralmente com alertas do Bootstrap)
            $(this).alert("close");
        });

    }, 4000);

   