function TestCanvas(id) {
    let canvas = document.getElementById(id);

    if (canvas == null) {
        return false;
    }

    let ctx = canvas.getContext("2d");
    ctx.fillStyle = "red";
    ctx.fillRect(10, 10, 20, 20);
}