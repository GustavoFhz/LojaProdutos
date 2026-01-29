// Aguarda o carregamento completo do DOM antes de executar o código
$(document).ready(function () {

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

});
