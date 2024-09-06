import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  constructor(private router: Router) {}

  linkTabelaPreco(): void {
    this.router.navigate(['lista-tabela-preco'])
  }
  linkVeiculos(): void {
    this.router.navigate(['lista-veiculos'])
  }
}
