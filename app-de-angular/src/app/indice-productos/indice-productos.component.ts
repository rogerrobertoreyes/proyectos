import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { LaptopService } from '../laptop.service';
import { Laptop, Personas } from '../laptop.models';
import { MatTableModule } from '@angular/material/table';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-indice-productos',
  standalone: true,
  imports: [MatButtonModule, RouterLink, MatTableModule, SweetAlert2Module],
  templateUrl: './indice-productos.component.html',
  styleUrl: './indice-productos.component.css'
})
export class IndiceProductosComponent {
  laptopService = inject(LaptopService);
  personas?: Personas[];
  columnasAMostrar = ['nombres', 'acciones']

  constructor(){
   this.cargarProductos();
  }

  cargarProductos(){
    this.laptopService.obtenerTodos().subscribe(personas => {
      this.personas = personas;
    });
  }

  borrar(id: number){
    this.laptopService.borrar(id).subscribe(() => {

      Swal.fire("Exitoso", "El registro ha sido borrado exitosamente", 'success');

      this.cargarProductos();
    });
  }
}
