import { Component, OnInit } from '@angular/core';
//import { FormBuilder } from '@angular/forms';
//import { NOMEM } from 'dns';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

  ordersForm = this.fb.group({
    provincia: [''],
    distrito: [''],
    calle: [''],
    numero: [''],
  });

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
  }

}