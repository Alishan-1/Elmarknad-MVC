$(document).ready(function () {
    
    var images = ["../../../Images/bild4.jpg", "../Images/bild1.jpg", "../Images/bild2.jpg","../Images/bild3.jpg"]
    var imageSrc = images[Math.floor(Math.random() * images.length)];
    $(".image-aboutus-banner").css("background", "linear-gradient(rgba(0,0,0,.5), rgba(0,0,0,.5)), url(" + imageSrc + ")");
});