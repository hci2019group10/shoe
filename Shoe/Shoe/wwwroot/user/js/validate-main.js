//validate form login
$(function () {
	$("form[name='loginForm']").validate({
		rules: {
			Email: {
				required: true,
				email: true,
			},
			Password: {
				required: true,
				minlength: 8,
			}
		},
		messages: {
			Email: {
				required: 'Bạn không thể để trống dữ liệu này',
				email: 'Email không hợp lệ',
			},
			Password: {
				required: 'Bạn không thể để trống dữ liệu này',
				minlength: 'Mật khẩu ít nhất 8 ký tự',
			}
		}
	});
});

// add to cart
var quantity = 1;
function addToCart(productID) {
	var userLogin = $('#account-link').val();
	quantity = quantity + 1;
		if (userLogin != null) {
			$.ajax({
				url: 'Cart/AddToCart',

				type: 'POST',
				data: {
					ProductId: productID,
					quanlity: 1
				},
				success: function (data) {
					
					$.notify("Đã thêm vào giỏ hàng", "success");
					$('.notifyjs-corner').css('top', '50%');
					$('.notifyjs-corner').css('right', '40%');
				}
			});
			
		}
}

//Xóa cart item ra khỏi cart
function deleteCartItem(itemID, btn) {
	$.ajax({
		url: 'Cart/deleteCartItem',
		type: 'DELETE',
		data: {
			cartItemID: itemID
		},
		success: function (data) {
			var row = btn.parentNode.parentNode;
			row.parentNode.removeChild(row);
		}
	});
}
