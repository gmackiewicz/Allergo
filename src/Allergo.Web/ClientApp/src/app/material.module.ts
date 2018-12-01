import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatCardModule, 
    MatButtonModule, 
    MatInputModule, 
    MatFormFieldModule,
    MatStepperModule,
    MatListModule,
    MatExpansionModule, 
    MatAutocompleteModule,
    MatDialogModule} 
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
        MatExpansionModule,
        MatAutocompleteModule,
        MatDialogModule
    ],
    exports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule,
        MatExpansionModule,
        MatAutocompleteModule,
        MatDialogModule
    ]
})
export class MaterialModule { }