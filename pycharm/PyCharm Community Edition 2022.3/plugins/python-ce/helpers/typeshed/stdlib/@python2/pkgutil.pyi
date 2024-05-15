from _typeshed import SupportsRead
from typing import IO, Any, Callable, Iterable, Iterator, Union

Loader = Any
MetaPathFinder = Any
PathEntryFinder = Any

_ModuleInfoLike = tuple[Union[MetaPathFinder, PathEntryFinder], str, bool]

def extend_path(path: list[str], name: str) -> list[str]: ...

class ImpImporter:
    def __init__(self, path: str | None = ...) -> None: ...

class ImpLoader:
    def __init__(self, fullname: str, file: IO[str], filename: str, etc: tuple[str, str, int]) -> None: ...

def find_loader(fullname: str) -> Loader | None: ...
def get_importer(path_item: str) -> PathEntryFinder | None: ...
def get_loader(module_or_name: str) -> Loader: ...
def iter_importers(fullname: str = ...) -> Iterator[MetaPathFinder | PathEntryFinder]: ...
def iter_modules(path: Iterable[str] | None = ..., prefix: str = ...) -> Iterator[_ModuleInfoLike]: ...
def read_code(stream: SupportsRead[bytes]) -> Any: ...  # undocumented
def walk_packages(
    path: Iterable[str] | None = ..., prefix: str = ..., onerror: Callable[[str], None] | None = ...
) -> Iterator[_ModuleInfoLike]: ...
def get_data(package: str, resource: str) -> bytes | None: ...