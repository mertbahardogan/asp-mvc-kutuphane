$(function () {
    var table = $(".tbldata").DataTable({
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
            [10, 13, 15, 25, -1],
            ["10", "13", "15", "25", "Tümü"]
        ],
        info: false
    });
});


$(function () {
    $(".table").on("click", ".btnSil", function () {
        var btn = $(this);
        var table = btn.parent().parent().parent().parent();
        table = $(table).DataTable();
        var row = btn.parent().parent();

        swal({
            title: "Emin misiniz?",
            text: "Seçtiğiniz veri kalıcı olarak silinmek üzere!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var id = btn.data("id");
                    var url = btn.data("url");
                    $.ajax({
                        type: "GET",
                        url: url + id,
                        success: function () {
                            table.row(row).remove().draw(true);
                            swal("Başarıyla silindi!", {
                                icon: "success",
                            });
                        }
                    })
                } else {
                    swal("Silmekten vazgeçildi!");
                }
            });
    });
})


//on: birden fazla event için on() açıp ayrı ayrı api gibi yazabiliriz. 

//click, double click(dblclick), mouse eventleri(mouse up ve mouse down..) , .after geçici ekleme yapar içine eklenicek html kod.


$(function () {
    $("#myform").on("click", ".btnEkle", function () {
        let form = $(this);
        let kategoriInput = $("#AD");
        let kategoriAdi = kategoriInput.val();
        //console.log(kategoriadi);
        $.ajax({
            type: "GET",
            url: "/Kategori/ekle?kategoriAdi=" + kategoriAdi,
            success: function (data) {
                swal(data["message"]);
            }
        })
    });
})

//$(function () {
//    $("form").submit(function () {
//        swal("Ekleme başarılı!", {
//            buttons: false,
//            timer: 30000,
//        });
//    }) //Süre halledilecek.
//})

$(".topSil").click(function () {
    var id = [];
    var sayac = 0;
    console.log("gird");
    $("input[name='secili']:checked").each(function () {
        id[sayac] = $(this).val();
        sayac++;
    });
    $.ajax({
        type: "POST",
        url: '/Kategori/TopluSil',
        data: { id },
        dataType: "json",
        success: function (gelenDeg) {
            if (gelenDeg === "1") {
                alert("Silme işlemi başarıyla gerçekleşti!");
            }
        },
        error: function () {
            alert("Makale(ler) Silinirken hata oluştu!");
        }
    });
});

