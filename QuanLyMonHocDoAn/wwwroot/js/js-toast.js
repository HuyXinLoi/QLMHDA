function toast({
    title = '',
    message = '',
    type = 'info',
    duration = 3000
}) {
    const main = document.getElementById('toast');
    if (main) {
        const toast = document.createElement('div');
        const fadeout = duration + 1000;
        //Auto remove toast
        const AutoRemoveId = setTimeout(function () {
            main.removeChild(toast);
        }, fadeout);

        //Remove toast when clicked
        toast.onclick = function (e) {
            if (e.target.closest('.toast__close')) {
                main.removeChild(toast);
                clearTimeout(AutoRemoveId);
            }
        }
        const icons = {
            success: 'fa-solid fa-circle-check',
            info: 'fa-solid fa-info',
            warning: 'fa-solid fa-triangle-exclamation',
            error: 'fa-solid fa-triangle-exclamation',
        };

        const icon = icons[type];
        const delay = (duration / 1000).toFixed(2);



        toast.classList.add('toast1', `toast--${type}`);
        toast.style.animation = `slideInFeft ease .3s,fadeOut linear 1s ${delay}s forwards`;
        toast.innerHTML = `
                <div class="toast__icon">
                    <i class="${icon}"></i>
                </div>
                <div class="toast__body">
                    <h3 class="toast__title">${title}</h3>
                    <p class="toast__msg">${message}</p>
                </div>
                <div class="toast__close">
                    <i class="fa-solid fa-xmark"></i>
                </div>`;
        main.appendChild(toast)

    }
}

function showSuccessToast() {
    toast({
        title: 'Thành công!',
        message: 'Phân công hội đồng thành công!',
        type: 'success',
        duration: 5000
    });
}
function showSuccessToastHoiDong() {
    toast({
        title: 'Thành công!',
        message: 'Thêm hội đồng thành công!',
        type: 'success',
        duration: 5000
    });
}


function showInfoToast() {
    toast({
        title: 'Thông tin!',
        message: 'Bạn đã đọc thông tin thông báo quan trọng này!',
        type: 'info',
        duration: 5000
    });
}

function showWarnToast() {
    toast({
        title: 'Cảnh báo!',
        message: 'Có lỗi xảy ra trong quá trình thêm!',
        type: 'warning',
        duration: 5000
    });
}
//Xóa hội đồng thành công
function showErrorToast() {
    toast({
        title: 'Thành công!',
        message: 'Xóa hội đồng thành công.',
        type: 'success',
        duration: 5000
    });
}
//THêm hội đồng thành công
function showSuccessToastPhanCongHoiDong() {
    toast({
        title: 'Thành công!',
        message: 'Phân Công Hội Đồng Thành Công.',
        type: 'success',
        duration: 5000
    });
}

//Sửa hội đồng thành công
function showSuccessToastfixPhanCongHoiDong() {
    toast({
        title: 'Thành công!',
        message: 'Sửa phân Công Hội Đồng Thành Công.',
        type: 'success',
        duration: 5000
    });
}

//phân công đề tài thành công
function showSuccessToastPhanCongDeTai() {
    toast({
        title: 'Thành công!',
        message: 'Phân công đề tài thành công!',
        type: 'success',
        duration: 5000
    });
}

//Xóa đề tài thành công
function showSuccessToastXoaDeTai() {
    toast({
        title: 'Thành công!',
        message: 'Xóa đề tài thành công!',
        type: 'success',
        duration: 5000
    });
}

//check phân công
function showErrorToastCheckPhanCong() {
    toast({
        title: 'Thông Báo!',
        message: 'Hội đồng đã được phân công!',
        type: 'warning',
        duration: 1500
    });
}
//Thông báo lỗi khi không chọn đầy đủ
function showInfoToastHD() {
    toast({
        title: 'Thông báo!',
        message: 'Vui Lòng chọn đầy đủ giảng viên!',
        type: 'info',
        duration: 1500
    });
}
//Thông báo lỗi khi giảng viên trùng
function showInfoToastcheckHD() {
    toast({
        title: 'Thông báo!',
        message: 'Giảng viên không được trùng nhau!',
        type: 'info',
        duration: 1500
    });
}
// CHeck sửa phân công
function showInfoToastcheckfixHD() {
    toast({
        title: 'Thông báo!',
        message: 'Hội đồng chưa được phân công! Không thể sửa',
        type: 'info',
        duration: 1500
    });
}

//check chọn hội đồng
function showInfoToastcheckchonHD() {
    toast({
        title: 'Thông báo!',
        message: 'Chưa phân công Hội đồng cho đề tài!',
        type: 'info',
        duration: 1500
    });
}


