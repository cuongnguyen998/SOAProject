var dssv = [
  new student('31161020013','Nguyễn Thị Minh An','16/12/1998','DH42BI002'),
  new student('31161021295','Phan Lương Minh An','10/10/1998','DH42BI001'),
  new student('31161020836','Đỗ Trọng Bình','11/11/1997','DH42BI002'),
  new student('31161024491','Vũ Thị Thanh Châu','09/01/1998','DH42BI002'),
  new student('31161023018','Cao Nguyễn Quỳnh Chi','04/05/1998','DH42BI001'),
  new student('31161021612','Nguyễn Quốc Cường','18/08/1998','DH42BI001'),
  new student('31161020017','Nguyễn Đình Khánh Du','22/08/1998','DH42BI002'),
  new student('31161020474','Phạm Anh Dũng','29/01/1998','DH42BI001'),
  new student('31161023792','Lê Thành Đạt','06/10/1998','DH42BI002'),
  new student('31161020515','Phạm Huỳnh Đức','30/08/1998','DH42BI001'),
  new student('31161024043','Bùi Sĩ Hiệp','07/04/1998','DH42BI001'),
  new student('31161025161','Hà Thanh Hoài','07/06/1998','DH42BI001'),
  new student('31161020990','Trần Khải Hoàn','08/05/1998','DH42BI001'),
  new student('31161026492','Chung Hoàng Khánh','15/03/1998','DH42BI001'),
  new student('31161026676','Nguyễn Ngọc Đăng Khoa','06/06/1998','DH42BI001'),
  new student('31161024815','Nguyễn Thụy Như Khuê','19/09/1998','DH42BI001'),
  new student('31161023705','Nguyễn Thị Hoài Linh','26/01/1998','DH42BI002'),
  new student('31161022233','Phạm Khánh Linh','05/11/1997','DH42BI002'),
  new student('31161024677','Phạm Hạnh Mai','28/03/1998','DH42BI002'),
  new student('31161021131','Nguyễn Hiếu Mỹ','28/03/1998','DH42BI002'),
  new student('31161024227','Nguyễn Hoàng Nam','04/03/1998','DH42BI001'),
  new student('31161025558','Nguyễn Xuân Ngọc','11/10/1998','DH42BI001'),
  new student('31161023543','Nguyễn Hà Thảo Nhi','27/07/1995','DH42BI001'),
  new student('31161021925','Quan Gia Nhi','19/09/1998','DH42BI002'),
  new student('31161021392','Lê Quỳnh Như','20/06/1998','DH42BI002'),
  new student('31161022532','Nguyễn Thanh Phong','26/02/1998','DH42BI001'),
  new student('31161022907','Trương Thu Phương','08/03/1998','DH42BI002'),
  new student('31161020183','Đỗ Minh Quân','17/12/1998','DH42BI001'),
  new student('31161023590','Nguyễn Ngọc Quỳnh','31/03/1998','DH42BI001'),
  new student('31161026660','Huỳnh Thị Lệ Thu','26/12/1998','DH42BI001'),
  new student('31161021419','Nguyễn Nhật Hoài','Thương','08/01/1998','DH42BI001'),
  new student('31161021641','Nguyễn Anh Thy','17/02/1998','DH42BI002'),
  new student('31161020484','Nguyễn Thụy Khánh Trang','16/03/1998','DH42BI002'),
  new student('31161026355','Mai Minh Trị','24/02/1998','DH42BI001'),
  new student('31161020232','Phạm Thị Bích Tuyền','20/03/1998','DH42BI001'),
  new student('31161024766','Võ Thị Hải Yến','05/02/1998','DH42BI002')
];

function parseJson(result){
  var dssv_detect = [];
  for (var i=0;i<result.length;i++)
  {
    for (var j=0;j<dssv.length;j++){
      if (result[i].Id == dssv[j].mssv)
        dssv_detect.push(dssv[j]);   
    }
  }
  return dssv_detect;
}

function createTable(dssv_detect){
  console.log(dssv_detect)
  for (var i=0;i<dssv_detect.length;i++){
    var d = new Date();
    var day = d.getDate();
    var month = d.getMonth()+1;
    var year = d.getFullYear();
    var hours = d.getHours();
    var minute = d.getMinutes();
    var strDate = `${day}/${month}/${year} vào lúc ${hours}:${minute}`
		//template String
		content +=`
		<tr>
			<td>${i+1}</td>
			<td>${dssv_detect[i].mssv}</td>
			<td>${dssv_detect[i].hoten}</td>
			<td>${dssv_detect[i].lop}</td>
			<td>${strDate}</td>
			<td>
				<button class="btn btn-danger" onclick="remove(${i})">
				Xóa
				</button>
			</td>
		</tr>
		`
  }
  $('#tbSinhVien').html(content);
}

$(document).ready(function(){
  $('#check_attend').click(function(){

    $('#body').addClass('darker');
    $('.loader').removeClass('d-none');

    var client = new studentService();
    client.layDanhSachSinhVienDiemDanh();
  });
});

$(function () {
    'use strict';

    // Initialize the jQuery File Upload widget:
    $('#fileupload').fileupload({
        // Uncomment the following to send cross-domain cookies:
        //xhrFields: {withCredentials: true},
        url: 'server/php/'
    });

    // Enable iframe cross-domain access via redirect option:
    $('#fileupload').fileupload(
        'option',
        'redirect',
        window.location.href.replace(
            /\/[^\/]*$/,
            '/cors/result.html?%s'
        )
    );

    if (window.location.hostname === 'blueimp.github.io') {
        // Demo settings:
        $('#fileupload').fileupload('option', {
            url: '//jquery-file-upload.appspot.com/',
            // Enable image resizing, except for Android and Opera,
            // which actually support image resizing, but fail to
            // send Blob objects via XHR requests:
            disableImageResize: /Android(?!.*Chrome)|Opera/
                .test(window.navigator.userAgent),
            maxFileSize: 999000,
            acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i
        });
        // Upload server status check for browsers with CORS support:
        if ($.support.cors) {
            $.ajax({
                url: '//jquery-file-upload.appspot.com/',
                type: 'HEAD'
            }).fail(function () {
                $('<div class="alert alert-danger"/>')
                    .text('Upload server currently unavailable - ' +
                        new Date())
                    .appendTo('#fileupload');
            });
        }
    } else {
        // Load existing files:
        $('#fileupload').addClass('fileupload-processing');
        $.ajax({
            // Uncomment the following to send cross-domain cookies:
            //xhrFields: {withCredentials: true},
            url: $('#fileupload').fileupload('option', 'url'),
            dataType: 'json',
            context: $('#fileupload')[0]
        }).always(function () {
            $(this).removeClass('fileupload-processing');
        }).done(function (result) {
            $(this).fileupload('option', 'done')
                .call(this, $.Event('done'), { result: result });
        });
    }
});