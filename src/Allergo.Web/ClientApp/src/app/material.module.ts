import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatCardModule, 
    MatButtonModule, 
    MatInputModule, 
    MatFormFieldModule } 
from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule
    ],
    exports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule
    ]
})
export class MaterialModule { }