import { Component } from '@angular/core';
import { fadeInLeftAnimation, fadeInRightAnimation, fadeOutAnimation, fadeInDownAnimation  } from 'angular-animations';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.scss'],
  animations: [
    fadeInDownAnimation({anchor: 'enter',delay: 2000}),
    fadeInLeftAnimation(),
    fadeInRightAnimation(),
    fadeOutAnimation()
  ]
})
export class HomeComponent {
  textAnimationBool = false;
  textanimationEnter = false;
  textanimationLeave = false;
  imageanimationEnter = false;
  imageanimationLeave = false;
  showAnimation = true;
 
  ngOnInit() { 
    this.animate();
  }
  animationDone(e){
    document.getElementById("banner-text1").style.display = "block";
    document.getElementById("banner-text1").style.left = "135px";
  };
  animate() {
    this.imageanimationEnter = false;
    this.textanimationEnter = false;
    setTimeout(() => {
      this.textAnimationBool = true;
      setTimeout(() => {
        this.textanimationEnter = true;
      });
    },2000);
    
    setTimeout(() => {
      this.imageanimationEnter = true;
    },1);
    setTimeout(() => {
      this.showAnimation = !this.showAnimation;
      this.animate();
    },4300);
  }
}
