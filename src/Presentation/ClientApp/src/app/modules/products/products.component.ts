import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { ProductsDataSource, ProductsItem } from './products-datasource';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductFormComponent } from './product-form/product-form.component';
import { InventaryFormComponent } from './inventary-form/inventary-form.component';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatTable) table: MatTable<any>;
  dataSource: any[];
  length = 0;
  filtro;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['code', 'description', 'category', 'price', 'stock', 'options'];

  constructor(public dialog: MatDialog, private productsService: ProductsService) { }

  ngOnInit() {
    this.loadProducts();
  }

  loadProducts() {
    this.productsService.GetAll().subscribe(x => {
      const items = (x as any[]);
      this.dataSource = items;
      this.length = items.length;
    });
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  openProductModal() {
    const dialogRef = this.dialog.open(ProductFormComponent, {
      data: {
        product: {}
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.productsService.New(result).subscribe(x => {
          this.loadProducts();
          alert('Producto Guardado!');
        }, err => {
          alert('No se pudo guardar!');
          console.log(err);
        });
      }
    });
  }

  openInventoryModal(product) {
    const dialogRef = this.dialog.open(InventaryFormComponent, {
      data: {
        productId: product.productId
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.productsService.AddInventory(result).subscribe(x => {
          this.loadProducts();
          alert('Stock Actualizado!');
        }, err => {
          alert('No se pudo guardar!');
        });
      }
    });

  }

  Update(row) {
    const dialogRef = this.dialog.open(ProductFormComponent, {
      data: {
        product: row
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.productsService.Update(result).subscribe(x => {
          this.loadProducts();
          alert('Producto actualizado!');
        }, err => {
          alert('No se pudo guardar!');
        });
      }
    });

  }

  Remove(row) {
    if (confirm('¿Está seguro que desea eliminar este producto? El stock también será eliminado.')) {
      this.productsService.Delete(row.productId).subscribe(x => {
        this.loadProducts();
        alert('Producto eliminado!');
      });
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filtro = filterValue.trim().toLowerCase();
  }

  search() {
    this.productsService.GetByFilter(this.filtro).subscribe(x => {
      const items = (x as any[]);
      this.dataSource = items;
    });
  }

}
