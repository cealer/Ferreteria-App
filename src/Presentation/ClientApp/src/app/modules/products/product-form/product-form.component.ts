import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {

  productForm;

  ngOnInit(): void {
    this.buildForm(this.data.product);
  }

  buildForm(itemForm) {
    this.productForm = this.fb.group({
      productId: [itemForm.productId || null, Validators.required],
      code: [itemForm.code || null, Validators.required],
      description: [itemForm.description || null, Validators.required],
      category: [itemForm.category || null, Validators.required],
      price: [itemForm.price || 0, Validators.required],
    });
  }

  constructor(private fb: FormBuilder, public dialogRef: MatDialogRef<ProductFormComponent>,
    // tslint:disable-next-line: align
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  onSubmit() {
    this.dialogRef.close(this.productForm.value);
  }
}
