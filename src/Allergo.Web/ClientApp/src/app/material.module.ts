import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatCardModule, 
    MatButtonModule, 
    MatInputModule, 
    MatFormFieldModule,
    MatStepperModule } 
from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule
    ],
    exports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule
    ]
})
export class MaterialModule { }