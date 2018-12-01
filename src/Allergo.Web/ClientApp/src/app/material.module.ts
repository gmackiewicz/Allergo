import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatCardModule, 
    MatButtonModule, 
    MatInputModule, 
    MatFormFieldModule,
    MatStepperModule,
    MatListModule,
    MatExpansionModule } 
from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule,
        MatExpansionModule
    ],
    exports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule,
        MatExpansionModule
    ]
})
export class MaterialModule { }