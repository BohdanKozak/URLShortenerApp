<script>
    function deleteUrlItem(id) {
        $.ajax({
            type: "DELETE",
            url: "/URLItem/Delete/" + id, // Замініть "YourControllerName" на реальне ім'я вашого контролера
            success: function (data) {
                // Обробка успішного видалення, якщо необхідно
                location.reload(); // Перезавантажте сторінку після видалення (можна зробити краще)
            },
            error: function (error) {
                // Обробка помилки, якщо необхідно
                console.log(error);
            }
        })
    }
</script>
