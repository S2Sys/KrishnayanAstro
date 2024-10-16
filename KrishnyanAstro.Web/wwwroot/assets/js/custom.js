
//horoscope dropdown js
document.addEventListener("DOMContentLoaded", function () {
  // Set the first option as selected by default
  const firstOption = document.querySelector(".option");
  const firstValue = firstOption.getAttribute("data-value");
  const firstText = firstOption.querySelector("span").textContent;
  const firstImgSrc = firstOption.querySelector("img").getAttribute("src");

  // Set the selected option text and image to the first option
  document.querySelector(
    ".selected"
  ).innerHTML = `<img src="${firstImgSrc}" style="width: 32px; height: 32px; margin-right: 10px;"> ${firstText}`;

  // Set the value in the hidden real select element
  document.getElementById("realSelect").value = firstValue;

  // Handle option click
  const options = document.querySelectorAll(".option");
  options.forEach(function (option) {
    option.addEventListener("click", function (e) {
      e.preventDefault(); // Prevent the link from navigating
      const value = option.getAttribute("data-value");
      const text = option.querySelector("span").textContent;
      const imgSrc = option.querySelector("img").getAttribute("src");

      // Set the selected option text and image
      document.querySelector(
        ".selected"
      ).innerHTML = `<img src="${imgSrc}" style="width: 32px; height: 32px; margin-right: 10px;"> ${text}`;

      // Set the value in the hidden real select element
      document.getElementById("realSelect").value = value;
    });
  });
});

// otp enter
document.addEventListener("DOMContentLoaded", function () {
  const otpInputs = document.querySelectorAll(".otp-input");

  // Handle input typing and auto-focus
  otpInputs.forEach((input, index) => {
    input.addEventListener("input", function (e) {
      const nextInput = otpInputs[index + 1];
      const currentValue = input.value;

      // Move to the next input if a digit is entered
      if (currentValue.length > 0 && nextInput) {
        nextInput.focus();
      }
    });
  });

  // Handle keydown for backspace and arrow key navigation
  otpInputs.forEach((input, index) => {
    input.addEventListener("keydown", function (e) {
      const prevInput = otpInputs[index - 1];
      const nextInput = otpInputs[index + 1];

      // Move focus to previous input on Backspace
      if (e.key === "Backspace" && input.value === "" && prevInput) {
        prevInput.focus();
      }

      // Move focus to next input on ArrowRight
      if (e.key === "ArrowRight" && nextInput) {
        nextInput.focus();
      }

      // Move focus to previous input on ArrowLeft
      if (e.key === "ArrowLeft" && prevInput) {
        prevInput.focus();
      }
    });
  });

  // Handle the paste event
  otpInputs.forEach((input, index) => {
    input.addEventListener("paste", function (e) {
      const pasteData = e.clipboardData.getData("text");
      if (pasteData.length === otpInputs.length && /^\d+$/.test(pasteData)) {
        otpInputs.forEach((otpInput, i) => {
          otpInput.value = pasteData[i];
        });
        otpInputs[otpInputs.length - 1].focus(); // Focus on the last field after pasting
      } else {
        e.preventDefault(); // Prevent invalid input if pasteData is incorrect
      }
    });
  });
});


 var pagesswiper = new Swiper(".heroswiper", {
	// Add Swiper options here
	slidesPerView: 1,
	
	spaceBetween: 16,
	autoplay: {
	  delay: 10000,
	},
	loop: true,
  });

  
 var  servicesSlider = new Swiper(".services-slider", {
	// Add Swiper options here
	slidesPerView: 1,

	autoplay: true,
	loop: true,
  breakpoints: {
    640: {
      slidesPerView: 1,
     
    },
    768: {
      slidesPerView: 2,
      spaceBetween: 20,
    },
    1024: {
      slidesPerView: 3,
      spaceBetween: 30,
    },
 
  },

  });
  
  var  videotestimonial = new Swiper(".video-testimonial", {
    // Add Swiper options here
    slidesPerView: 1,
  
    autoplay: true,
    loop: true,
    breakpoints: {
      640: {
        slidesPerView: 1,
       
      },
      768: {
        slidesPerView: 2,
        spaceBetween: 20,
      },
      1024: {
        slidesPerView: 4,
        spaceBetween: 15,
      },
   
    },
  
    });
    var  testimonialSlider = new Swiper(".ast_testimonials_slider", {
      // Add Swiper options here
      slidesPerView: 1,
    
      //autoplay: true,
      loop: true,
      breakpoints: {
        640: {
          slidesPerView: 1,
         
        },
        768: {
          slidesPerView: 2,
          spaceBetween: 20,
        },
        1024: {
          slidesPerView: 3,
          spaceBetween: 30,
        },
     
      },
    
      });


    var  blogslider = new Swiper(".blogs-slider", {
      // Add Swiper options here
      slidesPerView: 1,
    
      autoplay: true,
      loop: true,
      breakpoints: {
        640: {
          slidesPerView: 1,
         
        },
        768: {
          slidesPerView: 2,
          spaceBetween: 20,
        },
        1024: {
          slidesPerView: 3,
          spaceBetween: 30,
        },
     
      },
    
      });


     

    const toggleBtn = document.getElementById('helpcenter');
const slideElement = document.getElementById('helpdropdown');

// Toggle slide on button click
toggleBtn.onclick = function() {
    slideElement.classList.toggle('open');
};

// Close the slide when clicking outside of the element
document.addEventListener('click', function(event) {
    if (!slideElement.contains(event.target) && !toggleBtn.contains(event.target)) {
        slideElement.classList.remove('open');
    }
});
