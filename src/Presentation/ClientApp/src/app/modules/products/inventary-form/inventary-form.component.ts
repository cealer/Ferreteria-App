import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-inventary-form',
  templateUrl: './inventary-form.component.html',
  styleUrls: ['./inventary-form.component.scss']
})
export class InventaryFormComponent implements OnInit {

  inventoryForm;

  ngOnInit(): void {
    this.buildForm(this.data);
  }

  buildForm(itemForm) {
    this.inventoryForm = this.fb.group({
      productId: [itemForm.productId || null, Validators.required],
      quantity: [null, Validators.required]
    });
  }

  constructor(private fb: FormBuilder, public dialogRef: MatDialogRef<InventaryFormComponent>,
    // tslint:disable-next-line: align
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  onSubmit() {
    this.dialogRef.close(this.inventoryForm.value);
  }
}
