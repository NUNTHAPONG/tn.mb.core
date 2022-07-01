import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

export enum RowState {
    Normal, Add, Edit, Delete
}

export class BaseList {
    rowState: RowState;
    form?: FormGroup;
    constructor() {
        this.rowState = RowState.Add;
    }
}

@Injectable({ providedIn: 'root' })
export class BaseService {
    protected prepareSaveList(details: BaseList[], detailsDelete: BaseList[]): any[] {
        details = details.filter(item => item.rowState !== RowState.Normal)
            .map(({ ...prop }) => {
                try {
                    Object.assign(prop, prop.form.getRawValue());
                    delete prop.form;
                }
                catch(err){}
                return prop;
            }).concat(detailsDelete.map(({ form, ...prop }) => {prop.rowState = RowState.Delete; return prop;}));
        return details;
    }
}