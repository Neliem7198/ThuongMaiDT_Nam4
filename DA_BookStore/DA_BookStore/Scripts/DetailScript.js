function up(max) {
    document.getElementById("soLuong").value = parseInt(document.getElementById("soLuong").value) + 1;
    if (document.getElementById("soLuong").value >= parseInt(max)) {
        document.getElementById("soLuong").value = max;
    }
}
function down(min) {
    document.getElementById("soLuong").value = parseInt(document.getElementById("soLuong").value) - 1;
    if (document.getElementById("soLuong").value <= parseInt(min)) {
        document.getElementById("soLuong").value = min;
    }
}


//////Đang code ở đây
//function Deferred() {
//    var self = this;
//    this.promise = new Promise(function (resolve, reject) {
//        self.reject = reject
//        self.resolve = resolve
//    })
//}
//window.fbLoaded = (new Deferred());

