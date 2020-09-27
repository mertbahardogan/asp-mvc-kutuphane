(function($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
  });

})(jQuery);

$(function () {
	$("form").submit(function () {
		swal("Ýþlem baþarýlý!", {
			buttons: false,
			timer: 30000,
		});
	})
})

$(function () {
	$("#UyeForm").submit(function () {
		swal("Ýþlem baþarýlý!", {
			buttons: false,
			timer: 30000,
		});
	})
})