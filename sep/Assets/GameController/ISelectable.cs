﻿
public interface ISelectable {
    bool IsSelected { get; }
    void OnSelect();
    void OnDeselect();
}

