import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../shared/auth.service";
import {User} from "../../shared/user.model";
import {FormBuilder, FormControl, Validators} from "@angular/forms";
import {Router} from "@angular/router";




  @Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
    public password:string | undefined;
    passwordField:any| undefined;
    showOreHidePassword:any | undefined;


  constructor(private _authService: AuthService,
              private fb: FormBuilder,
              private _router: Router) {}



  ngOnInit(): void {
  }


  createUser(email: string, plainTextPassword: string, plaintTextRepeatPassword: string){
    if(this.checkIfPasswordsAreEqual(plainTextPassword, plaintTextRepeatPassword)){
      this.create(email, plainTextPassword);
      this.showPopUpWindow();
    }

  }

  showPopUpWindow(){
    // @ts-ignore
    document.querySelector('.pop-up_background').style.display = 'flex';
  }
  showPasswordWarning(){
    // @ts-ignore
    document.querySelector('.PasswordWarning').style.display = 'flex';
  }
  HidePasswordWarning(){
    // @ts-ignore
    document.querySelector('.PasswordWarning').style.display = 'none';
  }


  checkIfPasswordsAreEqual(plainTextPassword: string, plainTextRepeatPassword: string): boolean{
    if(plainTextPassword.length >0 && plainTextPassword == plainTextRepeatPassword){
      return true;
    }

    else{
      this.showPasswordWarning()
      return false;
    }
  }


  create(email: string, plainTextPassword: string): void {
    email = email.trim();
    plainTextPassword = plainTextPassword.trim();
    this._authService.createUser({email, plainTextPassword} as User).subscribe(value => {
    });
  }

  goBack(){
    window.history.back();
  }

  continue(){
    this._router.navigateByUrl('auth/login');
  }

    generateRandomPassword(){
      this.password='';
      var chars = "1234567890qwertzuiopasdfghjklyxcvbnm" +
        "QWERTZUIOPASDFGHJKLYXCVBNM!@$%&*()_+<>:{}[]";
      var passwordLength =16;
      for (var i=0; i< passwordLength; i++){
        var randomNumber = Math.floor(Math.random()* chars.length);
        this.password += chars.substring(randomNumber, randomNumber+1);
      }
      // @ts-ignore
      document.getElementById("password").value = this.password
      // @ts-ignore
      document.getElementById("repeatPassword").value = this.password
    }

    showPassword():void{
      if(!this.passwordField){
        this.passwordField = 1;
      }
      else{
        this.passwordField = undefined;
      }
    }


  }
