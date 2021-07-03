import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
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
