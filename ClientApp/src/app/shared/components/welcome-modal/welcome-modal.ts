import { Component, OnInit } from '@angular/core';

import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-welcome-modal',
  templateUrl: './welcome-modal.html',
  styleUrls: ['./welcome-modal.scss']
})

export class WelcomeModalComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<WelcomeModalComponent>) { }

  ngOnInit() {
  }

  closeModal() {
    this.dialogRef.close();
  }

}
