$(function () {
    var table = $(".table").DataTable({
        searching: true,
        paging: true,
        "language": {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt gösteriliyor.",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı.",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            },
            "buttons": {
                "colvisRestore": "Sıfırla"
            }
        },
        dom: "<'row mb-3'<'col-sm-4'l><'col-sm-4'B><'col-sm-4'f>>" + "<'row'<'col-sm-12't>>" + "<'row mt-3'<'col-sm-5'i><'col-sm-7'p>>",
        fixedColumns: {
            rightColumns: 1
        },
        buttons: [
            {
                extend: 'pdf',
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                },
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: ':visible:not(.not-export-col)'
                },
            },
            {
                extend: 'colvis',
                text: 'Sütun Seç',
                postfixButtons: ['colvisRestore']
            }
        ],
        "lengthMenu": [
            [5, 10, 15, 25, -1],
            ["5", "10", "15", "25", "Tümü"]
        ],
        info: false
    });
});


