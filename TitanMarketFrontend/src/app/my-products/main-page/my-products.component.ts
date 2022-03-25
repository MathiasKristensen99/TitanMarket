import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.scss']
})
export class MyProductsComponent implements OnInit {

  constructor(private _router: Router,
              private _activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
  }

  navigateToNewItem(){
    this._router.navigate(["new-item"],{relativeTo:this._activatedRoute});
  }
}
