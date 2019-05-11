function studentService(){

  this.layDanhSachSinhVienDiemDanh = function(){
    $.ajax({
      url: "http://localhost:50745/api/faces",
      type: "get",
    })
    .done(function(result){
      console.log(result);
      var dssv_detect = parseJson(result);
      createTable(dssv_detect);
      $('#body').removeClass('darker');
      $('.loader').addClass('d-none');
    })
    .fail(function(error){
      $('#body').removeClass('darker');
      $('.loader').addClass('d-none');
      console.log(error);
    })
  }
}