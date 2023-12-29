function displayAlert(event) {
    event.preventDefault();

    Swal.fire({
        title: 'Are you sure that you want to delete this bike?',
        icon: 'question',
        showCancelButton: true,
    }).then(result => {
        if (result.isConfirmed) {
            const deletingForm = document.getElementById('deletingForm');
            deletingForm.submit();
        }
    });
}