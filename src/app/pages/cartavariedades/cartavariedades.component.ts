import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { CartavariedadesService } from 'src/app/services/cartavariedades.service';
import { CartasService } from 'src/app/services/cartas.service';

@Component({
  selector: 'app-cartavariedades',
  templateUrl: './cartavariedades.component.html',
  styleUrls: ['./cartavariedades.component.css']
})
export class CartavariedadesComponent implements OnInit {

  project = [];
  apartments = [];

    constructor(private readonly cartasService: CartasService,
              private readonly cartavariedades: CartavariedadesService,
              private activeRoute: ActivatedRoute) { }

    getProjectById(id: number) {
                this.cartasService.getProject().subscribe((rest: any) => {
                  this.project = rest.data.filter((item: { id: number }) => item.id == id);
                  console.log(this.project);
                })
              }
    getApartmentsByProject(id: number) {
                this.cartavariedades.getApartments().subscribe((rest: any) => {
                  this.apartments = rest.data.filter((item: { projectId: number }) => item.projectId == id);
                })
              }



              ngOnInit(): void {
                this.activeRoute.params.subscribe((params: Params) => {
                  if(params.id) {
                    this.getProjectById(params.id);
                    this.getApartmentsByProject(params.id);
                  }
                })
              }
            }