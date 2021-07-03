import { Component, OnInit } from '@angular/core';
import { CartasService } from 'src/app/services/cartas.service';

@Component({
  selector: 'app-carta',
  templateUrl: './carta.component.html',
  styleUrls: ['./carta.component.css']
})
export class CartaComponent implements OnInit {
  projects = [];

  constructor(private readonly cartasService: CartasService) { }

  getProjects() {
    this.cartasService.getProject().subscribe((rest: any) => {
      ///console.log(rest.data);
      this.projects = rest.data;
    })
  }

  ngOnInit(): void {
    this.getProjects();
  }

}
