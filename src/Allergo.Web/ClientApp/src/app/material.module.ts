import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatCardModule, 
    MatButtonModule, 
    MatInputModule, 
    MatFormFieldModule,
    MatStepperModule,
    MatListModule } 
from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule
    ],
    exports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule
    ]
})
export class MaterialModule { }