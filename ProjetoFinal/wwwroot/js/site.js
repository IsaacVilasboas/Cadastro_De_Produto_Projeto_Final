$('.close-alert').click(function(){ //função para fechar mensagem de alerta
    $('.alert').hide('hide');
});


//função para executar a tabela do jquery, traduzida.
let table = new DataTable('#table-produtos', {
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
        "sLengthMenu": "Mostrar _MENU_ registros por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Próximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Último"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});

let precoInput = document.getElementById("precoInput");


precoInput.addEventListener("input", function () { //formatando o valor digitado pelo usúario
    let inputValue = precoInput.value;

    // Remover caracteres não numéricos
    let numericValue = inputValue.replace(/[^\d]/g, "");

    // Adicionar vírgula antes dos últimos dois dígitos
    let formattedValue = numericValue.replace(/(\d{2})$/, ',$1');

    precoInput.value = formattedValue;
});